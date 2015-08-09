using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace BelhardTraining.LessonMultithreading
{
	public partial class MainForm : Form
	{
		private readonly ListViewColumnSorter _columnSorter;
		static string[] SystemProcesses = { "System", "Idle", "audiodg" };

		public MainForm()
		{
			InitializeComponent();

			_columnSorter = new ListViewColumnSorter();
			processListView.ListViewItemSorter = _columnSorter;

			runElevatedToolStripMenuItem.Visible = !IsAdministrator();
		}

		#region Event handlers

		private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}

		private void OnRunToolStripMenuItemClick(object sender, EventArgs e)
		{
			var runForm = new RunForm();
			runForm.ShowDialog();
		}

		private void OnRunElevatedToolStripMenuItemClick(object sender, EventArgs e)
		{
			var runForm = new RunForm(true);
			runForm.ShowDialog();
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
				// TODO: Включить привилегию DEBUG для доступа к системным процессам
				Process[] processes = Process.GetProcesses()
					.OrderBy(p => String.Format("{0}#{1}", p.SessionId, p.ProcessName))
					.ToArray();
				foreach (Process p in processes)
				{
					var item = new ListViewItem(p.Id.ToString());
					item.SubItems.Add(p.ProcessName);
					item.SubItems.Add(p.Threads.Count.ToString());
					item.SubItems.Add(p.WorkingSet64.ToString("N0"));
					item.SubItems.Add(p.SessionId.ToString());

					if (!SystemProcesses.Contains(p.ProcessName))
					{
						try
						{
							string moduleFileName = p.MainModule.FileName;
							if (!imageListIcons.Images.ContainsKey(moduleFileName))
							{
								Icon icon = IconTools.GetIconForFile(moduleFileName, ShellIconSize.SmallIcon);
								if (icon != null)
								{
									imageListIcons.Images.Add(moduleFileName, icon);
								}
							}
							item.ImageKey = moduleFileName;
						}
						catch (Win32Exception)
						{
							Debug.WriteLine("Exception for: " + p.ProcessName);
						}
					}

					processListView.Items.Add(item);

					threadCount += p.Threads.Count;
				}

				// Скрываем или показываем колонку с номером сессии в зависимости от наличия 
				//	процессов запущенных в разных сессиях
				bool hasDifferentSessions = processes[0].SessionId != processes[processes.Length - 1].SessionId;
				bool sessionIdColumnVisible = processListView.Columns.Count == 5;
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
				infoToolStripStatusLabel.Text = String.Format(
							"CPUs - {0}, Processes - {1}. Threads - {2}",
							Environment.ProcessorCount, processes.Length, threadCount);
			}
			finally
			{
				processListView.EndUpdate();
			}
		}

		private static bool IsAdministrator()
		{
			WindowsIdentity identity = WindowsIdentity.GetCurrent();
			if (identity == null) return false;

			WindowsPrincipal principal = new WindowsPrincipal(identity);
			return principal.IsInRole(WindowsBuiltInRole.Administrator);
		}
	}
}
