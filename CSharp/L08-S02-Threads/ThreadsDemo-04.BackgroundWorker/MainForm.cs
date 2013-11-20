using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BelhardTraining.PiCalc
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnStartClick(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            lblProgress.Visible = true;
            btnStart.Enabled = false;
            btnCancel.Visible = true;

            const int numIterations = 10000000;
            backgroundWorker.RunWorkerAsync(numIterations);
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
        }

        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            worker.ReportProgress(0);

            PiCalculator piCalc = new PiCalculator();
            int numIterations = (int)e.Argument;
            for (int i = 0; i < 100; i++)
            {
                piCalc.Run(numIterations / 100);

                worker.ReportProgress(i, piCalc.PI);
                if (worker.CancellationPending) break;
            }
            worker.ReportProgress(100, piCalc.PI);
        }

        private void OnWorkProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tbResult.Visible = true;
            tbResult.Text = (string)e.UserState;
            lblProgress.Text = String.Format("Идет вычисление PI - {0:P0}", e.ProgressPercentage / 100f);
            progressBar.Value = e.ProgressPercentage;
        }

        private void OnWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblProgress.Visible = false;
            btnStart.Enabled = true;
            btnCancel.Visible = false;
        }
    }
}
