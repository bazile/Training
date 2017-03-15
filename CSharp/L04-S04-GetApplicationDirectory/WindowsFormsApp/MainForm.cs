using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrainingCenter.LessonIO
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			List<Tuple<string, string>> pathVariants = ApplicationDirectory.GetAll();

			listViewInfo.BeginUpdate();
			foreach (Tuple<string,string> pathVariant in pathVariants)
			{
				listViewInfo.Items.Add(new ListViewItem(new[] {pathVariant.Item1, pathVariant.Item2}));
			}
			listViewInfo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			listViewInfo.EndUpdate();
		}
	}
}
