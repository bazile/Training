using System;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace TrainingCenter.Extensions
{
	public static class StringExtensions
	{
		public static T ConvertToEnum<T>(this string value)
		{
			Contract.Requires(typeof(T).IsEnum);
			Contract.Requires(value != null);
			Contract.Requires(Enum.IsDefined(typeof(T), value));

			return (T)Enum.Parse(typeof(T), value);
		}
		
		/// <remarks>Строка неизменится если она состоит только из заглавных букв</remarks>
		public static string ToTitleCase(this string s)
		{
			Contract.Requires(s != null);

			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s);
		}

		/// <remarks>Строка неизменится если она состоит только из заглавных букв</remarks>
		public static string ToTitleCaseInvariant(this string s)
		{
			Contract.Requires(s != null);

			return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(s);
		}
	}
}
