using System;
using System.Windows.Forms;

namespace BelhardTraining.LessonIO.WindowsSearchDemo
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
