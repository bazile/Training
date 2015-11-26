﻿using System.Windows.Forms;

namespace BelhardTraining.Windows.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            FormManager.Show<ElevateButtonForm>();
        }

        private void btnLinkLabel_Click(object sender, System.EventArgs e)
        {
            FormManager.Show<LinkLabelForm>();
        }

        private void btlPlaceholderTextBox_Click(object sender, System.EventArgs e)
        {
            FormManager.Show<PlaceholderTextBoxForm>();
        }
    }
}
