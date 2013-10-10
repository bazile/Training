using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace SatelliteAssembliesDemo
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
			//Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
			//Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
