using System;
using System.IO;
using System.Windows.Forms;

namespace ProcessesDemo
{
	public partial class RunForm : Form
	{
		public RunForm()
		{
			InitializeComponent();
		}

		public string Arguments { get { return textBoxArguments.Text; } }
		public string FilePath { get { return textBoxPath.Text; } }

		private void OnRunFormLoad(object sender, EventArgs e)
		{
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

			textBoxPath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "notepad.exe");
			textBoxArguments.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "system.ini");
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
	}
}
