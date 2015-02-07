using System;
using System.Data.Common;

namespace BelhardTraining.Extensions
{
	public static class DbDataReaderExtensions
	{
		public static bool GetBoolean(this DbDataReader reader, string columnName)
		{
			return reader.GetBoolean(reader.GetOrdinal("columnName"));
		}

		public static byte GetByte(this DbDataReader reader, string columnName)
		{
			return reader.GetByte(reader.GetOrdinal("columnName"));
		}

		public static DateTime GetDateTime(this DbDataReader reader, string columnName)
		{
			return reader.GetDateTime(reader.GetOrdinal("columnName"));
		}

		public static decimal GetDecimal(this DbDataReader reader, string columnName)
		{
			return reader.GetDecimal(reader.GetOrdinal("columnName"));
		}

		public static double GetDouble(this DbDataReader reader, string columnName)
		{
			return reader.GetDouble(reader.GetOrdinal("columnName"));
		}

		public static Guid GetGuid(this DbDataReader reader, string columnName)
		{
			return reader.GetGuid(reader.GetOrdinal("columnName"));
		}

		public static short GetInt16(this DbDataReader reader, string columnName)
		{
			return reader.GetInt16(reader.GetOrdinal("columnName"));
		}

		public static int GetInt32(this DbDataReader reader, string columnName)
		{
			return reader.GetInt32(reader.GetOrdinal("columnName"));
		}

		public static long GetInt64(this DbDataReader reader, string columnName)
		{
			return reader.GetInt64(reader.GetOrdinal("columnName"));
		}

		public static bool? GetNullableBoolean(this DbDataReader reader, string columnName)
		{
			int columnIdx = reader.GetOrdinal("columnName");
			return reader.IsDBNull(columnIdx) ? null : (bool?)reader.GetBoolean(columnIdx);
		}

		public static byte? GetNullableByte(this DbDataReader reader, string columnName)
		{
			int columnIdx = reader.GetOrdinal("columnName");
			return reader.IsDBNull(columnIdx) ? null : (byte?)reader.GetByte(columnIdx);
		}

		public static DateTime? GetNullableDateTime(this DbDataReader reader, string columnName)
		{
			int columnIdx = reader.GetOrdinal("columnName");
			return reader.IsDBNull(columnIdx) ? null : (DateTime?)reader.GetDateTime(columnIdx);
		}

		public static decimal? GetNullableDecimal(this DbDataReader reader, string columnName)
		{
			int columnIdx = reader.GetOrdinal("columnName");
			return reader.IsDBNull(columnIdx) ? null : (decimal?)reader.GetDecimal(columnIdx);
		}

		public static double? GetNullableDouble(this DbDataReader reader, string columnName)
		{
			int columnIdx = reader.GetOrdinal("columnName");
			return reader.IsDBNull(columnIdx) ? null : (double?)reader.GetDouble(columnIdx);
		}

		public static Guid? GetNullableGuid(this DbDataReader reader, string columnName)
		{
			int columnIdx = reader.GetOrdinal("columnName");
			return reader.IsDBNull(columnIdx) ? null : (Guid?)reader.GetGuid(columnIdx);
		}

		public static short? GetNullableInt16(this DbDataReader reader, string columnName)
		{
			int columnIdx = reader.GetOrdinal("columnName");
			return reader.IsDBNull(columnIdx) ? null : (short?)reader.GetInt16(columnIdx);
		}

		public static int? GetNullableInt32(this DbDataReader reader, string columnName)
		{
			int columnIdx = reader.GetOrdinal("columnName");
			return reader.IsDBNull(columnIdx) ? null : (int?)reader.GetInt32(columnIdx);
		}

		public static long? GetNullableInt64(this DbDataReader reader, string columnName)
		{
			int columnIdx = reader.GetOrdinal("columnName");
			return reader.IsDBNull(columnIdx) ? null : (long?)reader.GetInt64(columnIdx);
		}

		public static string GetString(this DbDataReader reader, string columnName)
		{
			int columnIdx = reader.GetOrdinal("columnName");
			return reader.IsDBNull(columnIdx) ? null : reader.GetString(columnIdx);
		}
	}
}
