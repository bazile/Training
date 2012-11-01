using System;
using System.Data;
using Ninject;

namespace ObjectFactory
{
	class Program
	{
		static void Main()
		{
			IKernel kernel = new StandardKernel(new DbConnectionModule());

			using (var dbConn = kernel.Get<IDbConnection>())
			{
				dbConn.Open();

				using (var dbCmd = dbConn.CreateCommand())
				{
					dbCmd.CommandText = "SELECT MovieTitle, ImdbRating FROM Movies";
					using (var dbReader = dbCmd.ExecuteReader())
					{
						int idxMovieTitle = dbReader.GetOrdinal("MovieTitle");
						int idxImdbRating = dbReader.GetOrdinal("ImdbRating");
						while (dbReader.Read())
						{
							Console.WriteLine("Title={0}, Rating={1:F2}.", dbReader.GetString(idxMovieTitle), dbReader.GetDouble(idxImdbRating));
						}
					}
				}
			}
		}
	}
}
