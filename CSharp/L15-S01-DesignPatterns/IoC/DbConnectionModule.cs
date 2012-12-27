using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Ninject.Modules;

namespace Belhard.DesignPatterns.IoC
{
	internal class DbConnectionModule : NinjectModule
	{
		public override void Load()
		{
			string dbConnectionType = ConfigurationManager.AppSettings["dbConnectionType"];
			if (string.IsNullOrWhiteSpace(dbConnectionType))
			{
				throw new ConfigurationErrorsException("You need to specify value for 'dbConnectionType' key inside <appSettings>");
			}

			string connectionString = ConfigurationManager.AppSettings["dbConnectionString"];
			if (string.IsNullOrWhiteSpace(connectionString))
			{
				throw new ConfigurationErrorsException("You need to specify value for 'dbConnectionString' key inside <appSettings>");
			}
			connectionString = connectionString.Replace("$DbRoot$", GetDbRootFolder());

			Type t = typeof(IDbConnection).Assembly.GetType(dbConnectionType, false);
			if (t == null)
			{
				throw new ConfigurationErrorsException(String.Format("Unable to create type '{0}' from assembly '{1}'", dbConnectionType, typeof(IDbConnection).Assembly.FullName));
			}

			if (!typeof(IDbConnection).IsAssignableFrom(t))
			{
				throw new ConfigurationErrorsException(String.Format("Type '{0}' must implement System.Data.IDbConnection interface", dbConnectionType));
			}

			Kernel.Bind<IDbConnection>().To(t).WithConstructorArgument("connectionString", connectionString);
		}

		private static string GetDbRootFolder()
		{
			string assemblyLocation = Assembly.GetExecutingAssembly().Location;
			string rootFolder = Path.GetDirectoryName(assemblyLocation);
			Debug.Assert(rootFolder != null);

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
