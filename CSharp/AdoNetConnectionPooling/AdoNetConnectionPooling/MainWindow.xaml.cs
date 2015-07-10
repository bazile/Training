using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

// Идея: http://www.pythian.com/blog/sql-server-understanding-and-controlling-connection/

namespace BelhardTraining.ConnectionPoolingDemo
{
	public partial class MainWindow : Window
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

		PerformanceCounter[] _perfCounters;

		public MainWindow()
		{
			InitializeComponent();

			using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			using (var key = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL"))
			{
				string[] names = key.GetValueNames();
				if (names.Length > 0)
				{
					if ("MSSQLSERVER".Equals(names[0], StringComparison.OrdinalIgnoreCase))
					{
						tbServer.Text = "localhost";
					}
					else
					{
						tbServer.Text = @"localhost\" + names[0];
					}
				}
			}
		}

		private void CanExecuteStart(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = !string.IsNullOrWhiteSpace(tbServer.Text);
		}

		private void ExecuteStart(object sender, RoutedEventArgs e)
		{
			string connectionString = BuildConnectionString();
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(connectionString))
				{
					sqlConn.Open();
				}
			}
			catch (SqlException)
			{
				MessageBox.Show("Failed to open connection");
				return;
			}

			_perfCounters = InitPerformanceCounters();
			WritePerformanceCounters();

			for (int i = 0; i < 10; i++)
			{
				using (SqlConnection sqlConn = new SqlConnection(connectionString))
				{
					sqlConn.Open();
				}
			}

			WritePerformanceCounters();
		}

		private static PerformanceCounter[] InitPerformanceCounters()
		{
			var perfCounters = new PerformanceCounter[AdoNetPerfomanceCounters.Length];
			string instanceName = GetInstanceName();
			for (int i=0; i<AdoNetPerfomanceCounters.Length; i++)
			{
				perfCounters[i] = new PerformanceCounter {
					CategoryName = ".NET Data Provider for SqlServer",
					CounterName = AdoNetPerfomanceCounters[i],
					InstanceName = instanceName
				};
			}

			return perfCounters;
		}

		private void WritePerformanceCounters()
		{
			tbLog.AppendLine("---------------------------");
			foreach (PerformanceCounter pc in _perfCounters)
			{
				tbLog.AppendLine(string.Format("{0} = {1}", pc.CounterName, pc.NextValue()));
			}
			tbLog.AppendLine("---------------------------");
		}


		string BuildConnectionString()
		{
			var csb = new SqlConnectionStringBuilder();
			csb.DataSource = tbServer.Text.Trim();
			csb.IntegratedSecurity = !cbUseSqlAuth.IsChecked.Value;
			if (!csb.IntegratedSecurity)
			{
				csb.UserID = tbUserName.Text;
				csb.Password = tbPassword.Password;
			}
			csb.ApplicationName = Assembly.GetExecutingAssembly().GetName().Name;
			return csb.ConnectionString;
		}

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern IntPtr GetCurrentProcessId();

		static string GetInstanceName()
		{
			//This works for Winforms apps.
			string instanceName = Assembly.GetEntryAssembly().GetName().Name;

			//// Must replace special characters like (, ), #, /, \\
			//string instanceName2 =
			//	AppDomain.CurrentDomain.FriendlyName.ToString().Replace('(', '[')
			//	.Replace(')', ']').Replace('#', '_').Replace('/', '_').Replace('\\', '_');

			// For ASP.NET applications your instanceName will be your CurrentDomain's
			// FriendlyName. Replace the line above that sets the instanceName with this:
			// instanceName = AppDomain.CurrentDomain.FriendlyName.ToString().Replace('(','[')
			// .Replace(')',']').Replace('#','_').Replace('/','_').Replace('\\','_');

			string pid = GetCurrentProcessId().ToString();
			//instanceName = instanceName + "[" + pid + "]";
			////Console.WriteLine("Instance Name: {0}", instanceName);
			////Console.WriteLine("---------------------------");
			//return instanceName;
			return string.Format("{0}[{1}]", instanceName, pid);
		}
	}
}
