using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace CultureExplorer.WinForms
{
	public partial class MainForm : Form
	{
		#region Constructors

		public MainForm()
		{
			TypeDescriptor.AddProvider(new CultureExplorerTypeDescriptionProvider<Calendar,CalendarTypeDescriptor>(), typeof(Calendar));
			TypeDescriptor.AddProvider(new CultureExplorerTypeDescriptionProvider<CompareInfo,CompareInfoTypeDescriptor>(), typeof(CompareInfo));
			TypeDescriptor.AddProvider(new CultureExplorerTypeDescriptionProvider<DateTimeFormatInfo,DateTimeFormatInfoTypeDescriptor>(), typeof(DateTimeFormatInfo));
			TypeDescriptor.AddProvider(new CultureExplorerTypeDescriptionProvider<NumberFormatInfo,NumberFormatInfoTypeDescriptor>(), typeof(NumberFormatInfo));
			TypeDescriptor.AddProvider(new CultureExplorerTypeDescriptionProvider<TextInfo,TextInfoTypeDescriptor>(), typeof(TextInfo));

			InitializeComponent();

			InitViewMenu();
		} 

		#endregion

		#region Event Handlers

		private void OnMainFormLoad(object sender, EventArgs e)
		{
			DisplayCultures(CultureTypes.AllCultures);
		}

		private void OnViewMenuItemClick(object sender, EventArgs e)
		{
			foreach (ToolStripMenuItem menuItem in menuItemView.DropDownItems)
			{
				menuItem.Checked = false;
				menuItem.CheckState = CheckState.Unchecked;
			}

			var senderMenuItem = (ToolStripMenuItem)sender;
			senderMenuItem.Checked = true;
			senderMenuItem.CheckState = CheckState.Checked;

			DisplayCultures((CultureTypes)senderMenuItem.Tag);
		}

		private void OnExitMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}

		private void OnCulturesTreeViewAfterSelect(object sender, TreeViewEventArgs e)
		{
			//cultureInfoControl.SetDataSource((CultureInfo)e.Node.Tag);
			propertyGridCulture.SelectedObject = e.Node.Tag;
		}

		#endregion

		private void InitViewMenu()
		{
			AddViewMenuItem("&All cultures"            , true , CultureTypes.AllCultures);
			AddViewMenuItem("&Neutral cultures"        , false, CultureTypes.NeutralCultures);
			AddViewMenuItem("&Specific cultures"       , false, CultureTypes.SpecificCultures);
			AddViewMenuItem("Installed &Win32 cultures", false, CultureTypes.InstalledWin32Cultures);
		}

		private void AddViewMenuItem(string text, bool isChecked, CultureTypes cultureType)
		{
			var menuItem = new ToolStripMenuItem {Text = text};
			if (isChecked)
			{
				menuItem.Checked = true;
				menuItem.CheckState = CheckState.Checked;
			}
			menuItem.Tag = cultureType;
			menuItem.Click += OnViewMenuItemClick;

			menuItemView.DropDownItems.Add(menuItem);
		}

		private void DisplayCultures(CultureTypes cultureType)
		{
			treeViewCultures.BeginUpdate();
			try
			{
				treeViewCultures.Nodes.Clear();

				CultureInfo[] cultures = CultureInfo.GetCultures(cultureType);
				Array.Sort(cultures, new CultureInfoComparer());

				TreeNode parentNode = null;
				foreach (CultureInfo ci in cultures)
				{
					var node = new TreeNode {Text = ci.Name, Tag = ci};
					if (String.IsNullOrEmpty(node.Text))
					{
						node.Text = "<empty>";
					}
					if (ci.Name.Contains("-"))
					{
						if (parentNode != null)
							parentNode.Nodes.Add(node);
						else
							treeViewCultures.Nodes.Add(node);
					}
					else
					{
						parentNode = node;
						treeViewCultures.Nodes.Add(node);
					}
				}

				statusLabel.Text = String.Format("Number of cultures: {0}", cultures.Length);
			}
			finally
			{
				treeViewCultures.EndUpdate();
			}
		}
	}
}
