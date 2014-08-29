using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BelhardTraining.LessonMultithreading
{
	public partial class RunForm : Form
	{
		private bool _runElevated;

		public RunForm()
		{
			InitializeComponent();
		}

		public RunForm(bool runElevated) : this()
		{
			if (runElevated)
			{
				_runElevated = true;
				ShowShieldIcon(okButton.Handle);
			}
		}

		private void OnFormLoad(object sender, EventArgs e)
		{
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

			textBoxPath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "notepad.exe");
			textBoxArguments.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "system.ini");
		}

		private void OnFormClosed(object sender, FormClosedEventArgs e)
		{
			if (DialogResult == DialogResult.OK)
			{
				var startInfo = new ProcessStartInfo();
				if (_runElevated)
				{
					startInfo.Verb = "runas";
				}
				startInfo.FileName = textBoxPath.Text;
				startInfo.Arguments = textBoxArguments.Text;
				Process.Start(startInfo);

				// Для запуска без UAC - Process.Start("explorer.exe", "программа командаяСтрока");
			}
		}


		private void OnBrowseButtonClick(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				textBoxPath.Text = openFileDialog.FileName;
			}
		}

		private void OnOkButtonClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void ShowShieldIcon(IntPtr handle)
		{
			const uint BCM_SETSHIELD = 0x0000160C;
			IntPtr wParam = new IntPtr(0);
			IntPtr lParam = new IntPtr(1);
			SendMessage(new HandleRef(this, handle), BCM_SETSHIELD, wParam, lParam);
		}

		[DllImport("user32.dll")]
		private static extern IntPtr SendMessage(HandleRef hWnd, uint msg, IntPtr wParam, IntPtr lParam);
	}
}
