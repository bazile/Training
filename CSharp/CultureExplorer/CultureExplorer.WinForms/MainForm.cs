using System;
using System.Globalization;
using System.Windows.Forms;

namespace CultureExplorer.WinForms
{
	public partial class MainForm : Form
	{
		#region Constructors

		public MainForm()
		{
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
			cultureInfoBindingSource.DataSource = e.Node.Tag;
		}

		#endregion

		private void InitViewMenu()
		{
			AddViewMenuItem("&All", true, CultureTypes.AllCultures);
			AddViewMenuItem("&Neutral", false, CultureTypes.NeutralCultures);
			AddViewMenuItem("&Specific", false, CultureTypes.SpecificCultures);
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
					var node = new TreeNode {Text = ci.Name};
					node.Tag = ci;
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
