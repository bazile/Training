using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace ObjectFactory
{
	internal static class DbConnectionFactory
	{
		internal static IDbConnection GetDbConnection()
		{
			string provider = ConfigurationManager.AppSettings["dbProvider"];
			string connectionString = ConfigurationManager.AppSettings["dbConnectionString"];

			if (string.IsNullOrWhiteSpace(provider))
			{
				throw new ConfigurationErrorsException("You need to specify value for 'dbProvider' key inside <appSettings>");
			}
			if (string.IsNullOrWhiteSpace(connectionString))
			{
				throw new ConfigurationErrorsException("You need to specify value for 'dbConnectionString' key inside <appSettings>");
			}

			connectionString = connectionString.Replace("$DbRoot$", GetDbRootFolder());

			if (provider == "msssql")
			{
				var sqlConn = new SqlConnection(connectionString);
				return sqlConn;
			}
			if (provider == "msaccess")
			{
				var oleDbConn = new OleDbConnection(connectionString);
				return oleDbConn;
			}

			throw new ConfigurationErrorsException(String.Format("Unsupported value '{0}' specified for 'dbProvider' key. Supported values are 'msssql' and 'msaccess'.", provider));
		}

		private static string GetDbRootFolder()
		{
			string assemblyLocation = Assembly.GetExecutingAssembly().Location;
			string rootFolder = Path.GetDirectoryName(assemblyLocation);
			do
			{
				string dbRootFolder = Path.Combine(rootFolder, "Databases");
				if (Directory.Exists(dbRootFolder))
				{
					return dbRootFolder;
				}

				rootFolder = Path.GetDirectoryName(rootFolder);
			} while (rootFolder != null);

			throw new InvalidOperationException("Failed to find 'Databases' folder.");
		}
	}
}
