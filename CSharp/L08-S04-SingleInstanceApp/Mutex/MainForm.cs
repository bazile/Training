using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Belhard.Training.MutexDemo
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void OnExitButtonClick(object sender, EventArgs e)
		{
			Close();
		}

		private void OnRunButtonClick(object sender, EventArgs e)
		{
			string pathToSelf = Process.GetCurrentProcess().MainModule.FileName;
			Process.Start(pathToSelf);
		}
	}
}
