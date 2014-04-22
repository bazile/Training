using System;
using System.Windows.Forms;

namespace BelhardTraining.RecentListDemo
{
	public partial class MainForm : Form
	{
		private readonly RecentList<string> recentFiles;

		public MainForm()
		{
			InitializeComponent();

			recentFiles = new RecentList<string>(10);
		}

		private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}

		private void OnOpenToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				OpenFile(openFileDialog.FileName);
			}
		}

		private void OnFileToolStripMenuItemDropDownOpening(object sender, EventArgs e)
		{
			if (recentFiles.Count == 0)
			{
				recentToolStripMenuItem.Enabled = false;
			}
			else
			{
				recentToolStripMenuItem.Enabled = true;
				recentToolStripMenuItem.DropDownItems.Clear();

				foreach (string recentFileName in recentFiles)
				{
					ToolStripMenuItem menuItem = new ToolStripMenuItem(recentFileName);
					menuItem.Tag = recentFileName;
					menuItem.Click += OnRecentFileItemClick;
					recentToolStripMenuItem.DropDownItems.Add(menuItem);
				}
			}
		}

		private void OnRecentFileItemClick(object sender, EventArgs e)
		{
			ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
			string filePath = (string)menuItem.Tag;
			OpenFile(filePath);
		}

		private void OpenFile(string filePath)
		{
			listBoxFiles.Items.Add(filePath);
			recentFiles.Add(filePath);
		}
	}
}
