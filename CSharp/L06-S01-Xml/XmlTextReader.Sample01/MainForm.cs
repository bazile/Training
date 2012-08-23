using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using XmlSamples.Shared;

namespace XmlSamples.Sample01
{
	//TODO: correct support of list view groups when they are initially disabled

	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		#region Обработчики событий
		
		private void OnMainFormLoad(object sender, EventArgs e)
		{
			string customersXmlPath = Util.GetPathToCustomersXml();
			string customersXsdPath = Util.GetPathToCustomersXsd();

			List<Customer> customers;

			try
			{
				//customers = CustomerReader.GetCustomersUsingXmlReader(customersXmlPath);
				//customers = CustomerReader.GetCustomersUsingXmlDocument(customersXmlPath);
				//customers = CustomerReader.GetCustomersUsingXmlReader(customersXmlPath, customersXsdPath);
				customers = CustomerReader.GetCustomersUsingXmlDocument(customersXmlPath, customersXsdPath);
			}
			catch(CustomerLoadFailedException)
			{
				return;
			}

			DisplayCustomers(customers);
		}

		private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}

		private void OnShowGroupsToolStripMenuItemClick(object sender, EventArgs e)
		{
			showGroupsToolStripMenuItem.Checked = !showGroupsToolStripMenuItem.Checked;
			customersListView.ShowGroups = showGroupsToolStripMenuItem.Checked;
		}

		#endregion

		private void DisplayCustomers(IEnumerable<Customer> customers)
		{
			Debug.Assert(customers != null);

			// Говорим ListView чтобы он не перерисовывал свое содержимое т.к. мы собираемся добавлять много элементов за раз
			// Перерисовка не будет выполняться до вызова метода EndUpdate() 
			customersListView.BeginUpdate();

			try
			{
				var groupsDict = new SortedDictionary<string, ListViewGroup>();

				foreach (Customer customer in customers)
				{
					var item = new ListViewItem { Text = customer.CustomerId };
					item.SubItems.Add(customer.CompanyName);

					ListViewGroup itemGroup;
					if (!groupsDict.TryGetValue(customer.Country, out itemGroup))
					{
						itemGroup = new ListViewGroup(customer.Country);
						groupsDict.Add(customer.Country, itemGroup);
					}
					item.Group = itemGroup;

					customersListView.Items.Add(item);
				}

				// Добавляем группы к ListView после добавления всех элементов, чтобы группы показывались в алфавитном порядке
				foreach (KeyValuePair<string, ListViewGroup> kvp in groupsDict)
				{
					customersListView.Groups.Add(kvp.Value);
				}
			}
			finally
			{
				// Разрешаем перерисовку содержимого ListView
				// Делаем это в блоке finally чтобы оставить элемент управления ListView в корректном состоянии
				//	даже если в нашем коде возникнет исключение
				customersListView.EndUpdate();
			}
		}
	}
}
