#define USE_INVOKE // Закоментируйте эту строку чтобы получить ошибку "Cross-thread operation not valid: Control 'XXX' accessed from a thread other than the thread it was created on."

using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ThreadsDemo.WinForms.Invoke
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
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
				#if USE_INVOKE
					progressBar.SafeInvoke(IncrementProgress);
				#else
					IncrementProgress();
				#endif				
			}

			#if USE_INVOKE
				progressBar.SafeInvoke(EnableStartButton);
			#else
				EnableStartButton();
			#endif				
		}

		private void IncrementProgress()
		{
			progressBar.Value++;
		}

		private void EnableStartButton()
		{
			startButton.Enabled = true;
		}

        private void OnLoad(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(this.Width, this.Height);

            int maxWidth = Screen.AllScreens.Min(scr => scr.WorkingArea.Width);
            this.MaximumSize = new Size(maxWidth, this.Height);
        }
	}
}
