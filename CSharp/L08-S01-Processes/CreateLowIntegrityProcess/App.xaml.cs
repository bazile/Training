using System;
using System.Windows;

namespace BelhardTraining.LessonMultithreading
{
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			// Данное приложение следует запускать на компьютере с Windows Vista или 
			//	выше где поддерживается контроль учётных записей
			//	пользователей (UAC - User Account Control)
			if (Environment.OSVersion.Version.Major < 6)
			{
				MessageBox.Show(
					"Данное приложение следует запускать на компьютере с Windows Vista или "+
						"выше где поддерживается контроль учётных записей " +
						"пользователей (UAC - User Account Control)"
					, "Неподдерживаемая версия Windows"
					, MessageBoxButton.OK
					, MessageBoxImage.Warning
				);
				Shutdown(); // Завершить приложение
				return;
			}
			
			base.OnStartup(e);
		}
	}
}
