/*
 * Демонстрация чтения CSV файла с помощью класса TextFieldParser
 * http://msdn.microsoft.com/en-us/library/microsoft.visualbasic.fileio.textfieldparser.aspx
 *
 * Данный класс позволяет обрабатывать текстовые файлы с равномерной 
 *	структурой где значения отделены разделителями (запятая, 
 *	символ табуляции и т.п.) или где они выровнены по фиксированным
 *	позициям
 *	
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualBasic.FileIO;

namespace CsvReader
{
	class Program
	{
		static void Main()
		{
			List<MoonPhase> moonPhases = new List<MoonPhase>();
			
			using (TextFieldParser parser = new TextFieldParser(@"SQMData.csv"))
			{
				parser.TextFieldType = FieldType.Delimited;
				// Значения во входном файле разделены запятыми
				parser.SetDelimiters(",");
				// Указываем что следует игнорировать строки начинающиеся с # 
				parser.CommentTokens = new string[] {"#"};

				DateTime prevSkyclock = DateTime.MinValue;
				while (!parser.EndOfData)
				{
					string[] fields = null;
					try
					{
						fields = parser.ReadFields();
					}
					catch (MalformedLineException)
					{
						// Игнорируем "плохие" строки
						continue;
					}
					
					// Поля в файле
					//      0 - Year
					//      1 - Month
					//      2 - Day
					//      3 - Local_time
					//      4 - day_of_year
					//      5 - hour_of_day
					//      6 - Sky_Quality_(mag/arc_sec_**2)
					//      7 - SQM_temperature_(Celsius)
					//      8 - cloud_cover_(%)
					//      9 - seeing_(1-5)
					//     10 - transparency_(1-5)
					//     11 - skyclock_time/date_used
					//     12 - sunrise
					//     13 - sunset
					//     14 - moonrise
					//     15 - moonset
					//     16 - moonphase
					DateTime skyclock = DateTime.ParseExact(fields[11], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
					int moonPhase = int.Parse(fields[16]);
					
					if (prevSkyclock != skyclock.Date)
					{
						moonPhases.Add(new MoonPhase { Date = skyclock.Date, Phase = moonPhase });
						prevSkyclock = skyclock.Date;
					}
				}
			}

			foreach (MoonPhase phase in moonPhases)
			{
				Console.WriteLine("{0:d} - {1}", phase.Date, phase.Phase);
			}
		}
	}

	class MoonPhase
	{
		public DateTime Date { get; set; }
		public int Phase { get; set; }
	}
}
