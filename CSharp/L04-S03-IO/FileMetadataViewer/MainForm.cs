using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

namespace TrainingCenter.LessonIO
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			lvProperties.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		private void OnButtonBrowse_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				Cursor = Cursors.WaitCursor;

				AddToRecentList(openFileDialog.FileName);
				ShowProperties(openFileDialog.FileName);

				Cursor = Cursors.Default;
			}
		}

		private void OnRecentFiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			ShowProperties((string)cbRecentFiles.SelectedItem);

			Cursor = Cursors.Default;
			
		}

		private void AddToRecentList(string fileName)
		{
			const int maxRecentItems = 10;

			if (!cbRecentFiles.Items.Contains(openFileDialog.FileName))
			{
				if (cbRecentFiles.Items.Count + 1 > maxRecentItems)
				{
					cbRecentFiles.Items.RemoveAt(cbRecentFiles.Items.Count - 1);
				}

				cbRecentFiles.Items.Insert(0, openFileDialog.FileName);
				cbRecentFiles.SelectedIndex = 0;
			}
			else
			{
				cbRecentFiles.SelectedItem = fileName;
			}
		}

		private void ShowProperties(string fileName)
		{
			var properties = GetFileProperties(fileName);

			lvProperties.BeginUpdate();
			lvProperties.Items.Clear();
			var groupByName = new Dictionary<string, ListViewGroup>();
			foreach (var property in properties)
			{
				var listItem = new ListViewItem { Text = property.ShortName };
				listItem.SubItems.Add(property.Value);

				if (property.GroupName.Length > 0)
				{
					ListViewGroup listGroup;
					if (!groupByName.TryGetValue(property.GroupName, out listGroup))
					{
						listGroup = new ListViewGroup(property.GroupName);
						groupByName.Add(property.GroupName, listGroup);
						lvProperties.Groups.Add(listGroup);
					}
					listItem.Group = listGroup;
				}

				lvProperties.Items.Add(listItem);
			}

			lvProperties.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			lvProperties.EndUpdate();
		}

		private static ReadOnlyCollection<FileProperty> GetFileProperties(string fileName)
		{
			//var camera = GetValue(picture.Properties.GetProperty(SystemProperties.System.Photo.CameraModel));
			//var company = GetValue(picture.Properties.GetProperty(SystemProperties.System.Photo.CameraManufacturer));

			var properties = new List<FileProperty>();
			using (ShellObject shellObject = ShellObject.FromParsingName(fileName))
			{
				foreach (var shellProperty in shellObject.Properties.DefaultPropertyCollection)
				{
					string value = GetValue(shellProperty);
					if (string.IsNullOrEmpty(value) || shellProperty.CanonicalName == null) continue;

					properties.Add(new FileProperty(
								shellProperty.CanonicalName,
								shellProperty.Description.DisplayName,
								GetValue(shellProperty)
							)
					);
				}
			}

			properties.Sort((x, y) => string.CompareOrdinal(x.CanonicalName, y.CanonicalName));

			return properties.AsReadOnly();
		}

		private static string GetValue(IShellProperty value)
		{
			if (value == null || value.ValueAsObject == null)
			{
				return String.Empty;
			}

			return value.ValueAsObject.ToString();
		}
	}
}
