using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace BelhardTraining.UiCrossThreadAccessDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnStartClick(object sender, EventArgs e)
        {
            Thread calcThread = new Thread(CalculatePi);
            calcThread.Start();
        }

        private void CalculatePi()
        {
            const int numIterations = 10000000;

            PiCalculator piCalc = new PiCalculator();
            for (int i = 0; i < 100; i++)
            {
                piCalc.Run(numIterations / 100);

                ReportProgress(piCalc.PI, i);
            }

            ReportProgress(piCalc.PI, 100);
            lblProgress.Visible = false;
            btnStart.Enabled = true;
        }

        private void ReportProgress(string currentPi, int progressPercentage)
        {
            tbResult.Visible = true;
            tbResult.Text = currentPi;
            lblProgress.Text = String.Format("Идет вычисление PI - {0:P0}", progressPercentage / 100f);
            progressBar.Value = progressPercentage;
        }
    }
}
