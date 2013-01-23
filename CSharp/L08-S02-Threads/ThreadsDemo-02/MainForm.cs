using System;
using System.Threading;
using System.Windows.Forms;

namespace ThreadsDemo.WinForms.Invoke
{
	public partial class MainForm : Form
	{
		private delegate void InvokeDelegate();
		private readonly InvokeDelegate _incrementProgress;
		private readonly InvokeDelegate _enableStartButton;

		public MainForm()
		{
			InitializeComponent();

			_incrementProgress = IncrementProgress;
			_enableStartButton = EnableStartButton;
		}

		private void OnStartButtonClick(object sender, EventArgs e)
		{
			startButton.Enabled = false;
			progressBar.Value = 0;

			var longRunningThread = new Thread(LongRunningTask);
			longRunningThread.Start();
		}

		private void LongRunningTask()
		{
			for (int i=0; i<100; i++)
			{
				Thread.Sleep(75);
				//IncrementProgress();
				progressBar.Invoke(_incrementProgress);
			}

			//EnableStartButton();
			progressBar.Invoke(_enableStartButton);
		}

		private void IncrementProgress()
		{
			progressBar.Value++;
		}

		private void EnableStartButton()
		{
			startButton.Enabled = true;
		}
	}
}
