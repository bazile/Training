using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;

namespace TrainingCenter.ConnectionPoolingDemo
{
	class MainWindowPresenter
	{
		#region Названия счетчиков производительности

		static readonly string[] AdoNetPerfomanceCounters =
		{
			"NumberOfActiveConnectionPools",
			"NumberOfReclaimedConnections",
			"HardConnectsPerSecond",
			"HardDisconnectsPerSecond",
			"NumberOfActiveConnectionPoolGroups",
			"NumberOfInactiveConnectionPoolGroups",
			"NumberOfInactiveConnectionPools",
			"NumberOfNonPooledConnections",
			"NumberOfPooledConnections",
			"NumberOfStasisConnections",
			// The following performance counters are more expensive to track.
			// Enable ConnectionPoolPerformanceCounterDetail in your config file.
			//		<system.diagnostics>
			//		  <switches>
			//			<add name="ConnectionPoolPerformanceCounterDetail" value="4"/>
			//		  </switches>
			//		</system.diagnostics>
			//"SoftConnectsPerSecond",
			//"SoftDisconnectsPerSecond",
			//"NumberOfActiveConnections",
			//"NumberOfFreeConnections",
		};

		#endregion

		MainWindowViewModel _viewModel;
		PerformanceCounter[] _perfCounters;

		public MainWindowPresenter(MainWindowViewModel viewModel)
		{
			_viewModel = viewModel;
		}

		public void RunPoolTest()
		{
			try
			{
				string masterConnectionString = BuildConnectionString("master");
				List<string> databases = CreateDatabases(masterConnectionString, ToolSettings.NumDatabases);
				if (databases.Count != ToolSettings.NumDatabases)
				{
					DropDatabases(masterConnectionString, databases);
					return;
				}

				const string sqlQuery = "SELECT 'SessionID=' + CAST(@@SPID AS varchar(20))";

				_perfCounters = InitPerformanceCounters();
				WritePerformanceCounters();

				foreach (string dbName in databases)
				{
					using (SqlConnection sqlConn = new SqlConnection(BuildConnectionString(dbName)))
					{
						var sqlCmd = new SqlCommand(sqlQuery, sqlConn);

						sqlConn.Open();
						_viewModel.LogLines.AddLine((string)sqlCmd.ExecuteScalar());
					}
				}
				WritePerformanceCounters();

				//connectionString = BuildConnectionString("master");
				//for (int i = 0; i < 10; i++)
				//{
				//	using (SqlConnection sqlConn = new SqlConnection(connectionString))
				//	{
				//		var sqlCmd = new SqlCommand(sqlQuery, sqlConn);

				//		sqlConn.Open();
				//		tbQueryOutput.AppendText((string)sqlCmd.ExecuteScalar() + "\r\n");
				//	}
				//}
				//WritePerformanceCounters();

				DropDatabases(masterConnectionString, databases);

				_viewModel.LogLines.AddLine("");
				_viewModel.LogLines.AddLine("Тестирование закончено");
			}
			finally
			{
				_viewModel.PoolTestRunning = false;
			}
		}

		string BuildConnectionString(string databaseName = null)
		{
			var csb = new SqlConnectionStringBuilder();
			csb.DataSource = _viewModel.Server;
			csb.IntegratedSecurity = !_viewModel.UseSqlAuthentication;
			if (!csb.IntegratedSecurity)
			{
				csb.UserID = _viewModel.UserName;
				csb.Password = _viewModel.Password;
			}
			csb.ApplicationName = Assembly.GetExecutingAssembly().GetName().Name;
			if (databaseName != null) csb.InitialCatalog = databaseName;
			return csb.ConnectionString;
		}

		List<string> CreateDatabases(string connectionString, int count)
		{
			List<string> databases = new List<string>();

			SqlConnection sqlConn;
			try
			{
				_viewModel.LogLines.AddLine("Проверка подключения к SQL Server");
				sqlConn = new SqlConnection(connectionString);
				sqlConn.Open();

				var sqlCmd = new SqlCommand("SELECT @@VERSION", sqlConn);
				_viewModel.LogLines.AddLine("Версия SQL Server: " + (string)sqlCmd.ExecuteScalar());
			}
			catch (SqlException)
			{
				_viewModel.LogLines.AddLine("Ошибка при подключении к SQL Server");
				return databases;
			}

			try
			{
				for (int i = 1; i <= count; i++)
				{
					string dbName = string.Format("{0}{1:00}", ToolSettings.DatabaseName, i);
					_viewModel.LogLines.AddLine("Создание базы данных [" + dbName + "]");
					var sqlCmd = new SqlCommand("CREATE DATABASE [" + dbName + "]", sqlConn);
					sqlCmd.ExecuteNonQuery();
					databases.Add(dbName);
				}
			}
			catch (SqlException)
			{
				_viewModel.LogLines.AddLine("Не удалось создать базу данных");
				return databases;
			}
			finally
			{
				sqlConn.Close();
			}

			return databases;
		}

		void DropDatabases(string connectionString, IList<string> databases)
		{
			if (databases.Count == 0) return;

			using (var sqlConn = new SqlConnection(connectionString))
			{
				sqlConn.Open();

				foreach (string dbName in databases)
				{
					var dropCmd = new SqlCommand();
					_viewModel.LogLines.AddLine("Удаление базы данных [" + dbName + "]");
					dropCmd.CommandText = string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [{0}]", dbName);
					dropCmd.Connection = sqlConn;
					dropCmd.ExecuteNonQuery();
				}
			}
		}

		private static PerformanceCounter[] InitPerformanceCounters()
		{
			var perfCounters = new PerformanceCounter[AdoNetPerfomanceCounters.Length];
			string instanceName = App.GetInstanceName();
			for (int i = 0; i < AdoNetPerfomanceCounters.Length; i++)
			{
				perfCounters[i] = new PerformanceCounter
				{
					CategoryName = ".NET Data Provider for SqlServer",
					CounterName = AdoNetPerfomanceCounters[i],
					InstanceName = instanceName
				};
			}

			return perfCounters;
		}

		private void WritePerformanceCounters()
		{
			_viewModel.CountersLines.AddLine("---------------------------");
			foreach (PerformanceCounter pc in _perfCounters)
			{
				_viewModel.CountersLines.AddLine(string.Format("{0} = {1}", pc.CounterName, pc.NextValue()));
			}
			_viewModel.CountersLines.AddLine("---------------------------");
		}
	}
}
