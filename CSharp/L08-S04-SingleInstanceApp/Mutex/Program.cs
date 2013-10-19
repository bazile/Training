using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Belhard.Training.MutexDemo
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			//Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
			//Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru-RU");

			bool createdNew;
			var appMutex = new Mutex(true, "MutexDemo.{2B293B02-D2F5-4CE6-8F61-F103E5AC6F51}", out createdNew);

			try
			{
				if (createdNew)
				{
					RunNewInstance();
				}
				else
				{
					ActivateRunningInstance();
				}
			}
			finally
			{
				if (createdNew)
				{
					appMutex.ReleaseMutex();
				}
			}

			// Вызов GC.KeepAlive гарантирует что переменная appMutex не будет удалена сборщиком мусора
			//  до конца работы функции Main, то есть всего приложения.
			// Досрочное освобождение мьютекса позволит запустить несколько копий приложения т.к. наше приложение
			//  потеряет его монопольное владение
			GC.KeepAlive(appMutex);
		}

		private static void RunNewInstance()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}

		private static void ActivateRunningInstance()
		{
			Process previousInstance = FindPreviousInstance();
			if (previousInstance != null)
			{
				SetForegroundWindow(previousInstance.MainWindowHandle);
			}
		}

		private static void SetForegroundWindow(IntPtr windowHandle)
		{
			if (windowHandle == IntPtr.Zero) return;

			//Native.WINDOWPLACEMENT placement = Native.WINDOWPLACEMENT.Default;
			//if (Native.GetWindowPlacement(windowHandle, out placement))
			//{
			//    if (placement.ShowCmd == Native.ShowWindowCommands.Minimize)
			//    {
			//        Native.ShowWindow(windowHandle, Native.ShowWindowCommands.Restore);
			//    }
			//}

			Native.SetForegroundWindow(windowHandle);
		}

		private static Process FindPreviousInstance()
		{
			Process curInstance = Process.GetCurrentProcess();
			Process[] otherInstances = Process.GetProcessesByName(curInstance.ProcessName)
										.Where(p => p.Id != curInstance.Id && p.MainModule.FileName == curInstance.MainModule.FileName)
										.ToArray();
			return otherInstances.Length != 1 ? null : otherInstances[0];
		}

	}
}
