using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace ProcessesDemo
{
	public partial class MainForm : Form
	{
		private readonly ListViewColumnSorter _columnSorter;

		public MainForm()
		{
			InitializeComponent();

			_columnSorter = new ListViewColumnSorter();
			processListView.ListViewItemSorter = _columnSorter;
		}

		#region Event handlers

		private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}

		private void OnRunToolStripMenuItemClick(object sender, EventArgs e)
		{
			var runForm = new RunForm();
			if (runForm.ShowDialog() == DialogResult.OK)
			{
				var startInfo = new ProcessStartInfo();
				startInfo.FileName = runForm.FilePath;
				startInfo.Arguments = runForm.Arguments;
				Process.Start(startInfo);
			}
		}

		private void OnMainFormClosing(object sender, FormClosingEventArgs e)
		{
			refreshTimer.Enabled = false;
		}

		private void OnMainFormLoad(object sender, EventArgs e)
		{
			RefreshProcessList();

			refreshTimer.Enabled = true;
		}

		private void OnProcessListViewColumnClick(object sender, ColumnClickEventArgs e)
		{
			// Determine if clicked column is already the column that is being sorted.
			if (e.Column == _columnSorter.SortColumn)
			{
				// Reverse the current sort direction for this column.
				_columnSorter.Order = _columnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
			}
			else
			{
				// Set the column number that is to be sorted; default to ascending.
				_columnSorter.SortColumn = e.Column;
				_columnSorter.Order = SortOrder.Ascending;
			}

			// Perform the sort with these new sort options.
			processListView.Sort();
		}

		private void OnRefreshTimerTick(object sender, EventArgs e)
		{
			RefreshProcessList();
		}

		private void OnAutoRefreshToolStripMenuItemCheckedChanged(object sender, EventArgs e)
		{
			SetRefreshTimer(autoRefreshToolStripMenuItem.Checked);
			autoRefreshToolStripButton.Checked = autoRefreshToolStripMenuItem.Checked;
		}

		private void OnAutoRefreshToolStripButtonCheckStateChanged(object sender, EventArgs e)
		{
			SetRefreshTimer(autoRefreshToolStripButton.Checked);
			autoRefreshToolStripMenuItem.Checked = autoRefreshToolStripButton.Checked;
		}

		#endregion

		private void SetRefreshTimer(bool enabled)
		{
			refreshTimer.Enabled = enabled;
		}

		private void RefreshProcessList()
		{
			processListView.BeginUpdate();

			try
			{
				processListView.Items.Clear();

				// Заполняем ListView списоком процессов
				int threadCount = 0;
				// Получаем список процеесов отсортированных по номеру сессии и имени процесса
				Process[] processes = Process.GetProcesses()
					.OrderBy(p => String.Format("{0}#{1}", p.SessionId, p.ProcessName))
					.ToArray();
				foreach (Process p in processes)
				{
					var item = new ListViewItem(p.Id.ToString());
					item.SubItems.Add(p.ProcessName);
					item.SubItems.Add(p.Threads.Count.ToString());
					item.SubItems.Add(p.SessionId.ToString());
					processListView.Items.Add(item);

					threadCount += p.Threads.Count;
				}

				// Скрываем или показываем колонку с номером сессии в зависимости от наличия 
				//	процессов запущенных в разных сессиях
				bool hasDifferentSessions = processes[0].SessionId != processes[processes.Length - 1].SessionId;
				bool sessionIdColumnVisible = processListView.Columns.Count == 4;
				if (hasDifferentSessions)
				{
					if (!sessionIdColumnVisible)
					{
						processListView.Columns.Insert(columnHeaderSessionId.DisplayIndex, columnHeaderSessionId);
					}
				}
				else
				{
					if (sessionIdColumnVisible)
					{
						processListView.Columns.Remove(columnHeaderSessionId);
					}
				}

				// Обновляем статистику в строке статуса
				infoToolStripStatusLabel.Text = String.Format("Processes - {0}. Threads - {1}", processes.Length, threadCount);
			}
			finally
			{
				processListView.EndUpdate();
			}

			//_columnSorter.SortColumn = 1;
			//_columnSorter.Order = SortOrder.Ascending;
			//processListView.Sort();
		}

	}
}
