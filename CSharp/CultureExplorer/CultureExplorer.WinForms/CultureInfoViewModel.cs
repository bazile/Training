using System;
using System.Globalization;

namespace CultureExplorer.WinForms
{
	internal class CultureInfoViewModel
	{
		public string CalendarAlgorithmType { get; private set; }
		//public string CalendarCurrentEra { get; private set; }
		public string CalendarType { get; private set; }
		public string MonthsInYear { get; private set; }
		public string FullDateTimePattern { get; private set; }
		public string Name { get; private set; }
		public string DisplayName { get; private set; }
		public string NativeName { get; private set; }
		public string EnglishName { get; private set; }
		public string LCID { get; private set; }
		public string NativeDigits { get; private set; }
		public string MonthNames { get; private set; }

		public CultureInfoViewModel(CultureInfo cultureInfo)
		{
			CalendarAlgorithmType = cultureInfo.Calendar.AlgorithmType.ToString();
			//CalendarCurrentEra = cultureInfo.Calendar.Eras[0].ToString();
			CalendarType = cultureInfo.Calendar.GetType().Name;
			try
			{
				MonthsInYear = cultureInfo.Calendar.GetMonthsInYear(DateTime.Now.Year).ToString();
			}
			catch(ArgumentOutOfRangeException)
			{
				MonthsInYear = "<undefined>";
			}
			MonthNames = String.Join(",", cultureInfo.DateTimeFormat.MonthNames);
			FullDateTimePattern = cultureInfo.DateTimeFormat.FullDateTimePattern;

			Name = cultureInfo.Name;
			DisplayName = cultureInfo.DisplayName;
			EnglishName = cultureInfo.EnglishName;
			NativeName = cultureInfo.NativeName;

			LCID = cultureInfo.LCID.ToString();

			NativeDigits = string.Join(",", cultureInfo.NumberFormat.NativeDigits);
		}

	}
}
