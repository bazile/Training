using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace BelhardTraining.EncodingViewer
{
	public partial class MainForm2 : Form
	{
		public MainForm2()
		{
			InitializeComponent();
		}

		private void FormLoad(object sender, System.EventArgs e)
		{
			//dataGridView1.Rows.Add("1", "2");
			//dataGridView1.Rows.Add("3", "4");

			//dataGridView1.Rows[0].HeaderCell.Value = "UTF-8";
			//dataGridView1.Rows[0].HeaderCell.Value = "UTF-16";
			
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();

			List<Encoding> encodings = new List<Encoding>();
			encodings.Add(Encoding.ASCII);
			encodings.Add(Encoding.UTF8);
			string text = "Привет123";
			for (int i=0; i<text.Length; i++)
			{
				DataGridViewColumn column = new DataGridViewButtonColumn();
				column.HeaderText = text.Substring(i, 1);
				dataGridView1.Columns.Add(column);
			}

			byte[] buf = new byte[8];
			//string s = text.Substring(i, 1);
			foreach (Encoding encoding in encodings)
			{
				DataGridViewRow row = dataGridView1.Rows[dataGridView1.Rows.Add()];
				row.HeaderCell.Value = encoding.EncodingName;

				if (encoding.IsSingleByte)
				{
					for (int i = 0; i < text.Length; i++)
					{
						int count = encoding.GetBytes(text, i, 1, buf, 0);
						Debug.Assert(count == 1);

						row.Cells[i].Value = buf[0].ToString("X2");
					}
				}
				else
				{
					for (int i = 0; i < text.Length; i++)
					{
						int count = encoding.GetBytes(text, i, 1, buf, 0);
						row.Cells[i].Value = BitConverter.ToString(buf, 0, count);
					}
				}
			}
		}
	}
}
