using System;
using System.Numerics;
using System.Reflection;
using System.Windows;

namespace TrainingCenter.LessonThreading
{
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			NativeHelper.DisableWindowsErrorReporting();

			//Type vectorType = typeof(Vector2).Assembly.GetType("System.Numerics.Vector", true);
			//bool isHardwareAccelerated = (bool)vectorType.GetProperty("IsHardwareAccelerated", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty).GetValue(null);
			//if (!isHardwareAccelerated)
			//{
			//	//MessageBox.Show("Аппаратное ускорение не может использоваться на данном комьютере.", "Уведомление",
			//	//	MessageBoxButton.OK, MessageBoxImage.Information);
			//}

			//base.OnStartup(e);
		}
	}
}
