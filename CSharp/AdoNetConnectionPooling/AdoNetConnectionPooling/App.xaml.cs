using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;

namespace TrainingCenter.ConnectionPoolingDemo
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		static extern IntPtr GetCurrentProcessId();

		public static string GetInstanceName()
		{
			//This works for Winforms apps.
			string instanceName = Assembly.GetEntryAssembly().GetName().Name;

			//// Must replace special characters like (, ), #, /, \\
			//string instanceName2 =
			//	AppDomain.CurrentDomain.FriendlyName.ToString().Replace('(', '[')
			//	.Replace(')', ']').Replace('#', '_').Replace('/', '_').Replace('\\', '_');

			// For ASP.NET applications your instanceName will be your CurrentDomain's
			// FriendlyName. Replace the line above that sets the instanceName with this:
			// instanceName = AppDomain.CurrentDomain.FriendlyName.ToString().Replace('(','[')
			// .Replace(')',']').Replace('#','_').Replace('/','_').Replace('\\','_');

			string pid = GetCurrentProcessId().ToString();
			return string.Format("{0}[{1}]", instanceName, pid);
		}

	}
}
