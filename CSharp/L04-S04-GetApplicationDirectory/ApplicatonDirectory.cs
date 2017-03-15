using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace TrainingCenter.LessonIO
{
	public static partial class ApplicationDirectory
	{
		public static List<Tuple<string, string>> GetAll()
		{
			var directoryInfo = GetApplicationAgnosticInfo();
			AddApplicationSpecificInfo(directoryInfo);
			return directoryInfo;
		}

		/// <summary>
		/// Получение информации о каталоге приложения с помощью классов
		///		которые доступны во всех .NET приложениях
		/// </summary>
		private static List<Tuple<string, string>> GetApplicationAgnosticInfo()
		{
			return new List<Tuple<string, string>> {
				Tuple.Create("AppDomain.BaseDirectory"             , AppDomain.CurrentDomain.BaseDirectory),
				Tuple.Create("Assembly.Location (entry)"           , Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)),
				Tuple.Create("Assembly.Location (executing)"       , Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)),
				Tuple.Create("Assembly.EscapedCodeBase (entry)"    , Path.GetDirectoryName(new Uri(Assembly.GetEntryAssembly().EscapedCodeBase).LocalPath)),
				Tuple.Create("Assembly.EscapedCodeBase (executing)", Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().EscapedCodeBase).LocalPath)),
				Tuple.Create("Process.MainModule.FileName"         , Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName)),
				Tuple.Create("Environment.GetCommandLineArgs()"    , Path.GetDirectoryName(Environment.GetCommandLineArgs()[0])),

				// Свойства и методы возвращающие "текущий каталог" являются ненадежными
				// НЕ ПОЛЬЗУЙТЕСь ИМИ!
				Tuple.Create("Environment.CurrentDirectory"        , Environment.CurrentDirectory),
				Tuple.Create("Directory.GetCurrentDirectory()"     , Directory.GetCurrentDirectory()),
			};
		}

		static partial void AddApplicationSpecificInfo(List<Tuple<string, string>> directoryInfo);
	}
}
