using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using XmlSamples.Shared;

namespace XmlSamples.Sample01
{
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
			List<Customer> customers = GetCustomersUsingXmlTextReader(customersXmlPath);
			//List<Customer> customers = GetCustomersUsingXmlDocument(customersXmlPath);
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

		private void DisplayCustomers(List<Customer> customers)
		{
			Dictionary<string, ListViewGroup> groupsDict = new Dictionary<string, ListViewGroup>();

			foreach (Customer customer in customers)
			{
				ListViewItem item = new ListViewItem();
				item.Text = customer.CustomerId;
				item.SubItems.Add(customer.CompanyName);

				ListViewGroup itemGroup;
				if (!groupsDict.TryGetValue(customer.Country, out itemGroup))
				{
					itemGroup = new ListViewGroup(customer.Country);
					groupsDict.Add(customer.Country, itemGroup);
					customersListView.Groups.Add(itemGroup);
				}
				item.Group = itemGroup;

				customersListView.Items.Add(item);
			}
		}

		/// <summary>
		/// Возращает список клиентов прочитанный из указанного XML файла с помощью класса XmlDocument
		/// </summary>
		/// <param name="customersXmlPath">Путь к файлу customers.xml</param>
		/// <returns>Cписок клиентов</returns>
		/// <remarks>Обратите внимание, что мы всегда возврашаем коллекцию даже если ничего не прочитали из файла</remarks>
		private List<Customer> GetCustomersUsingXmlDocument(string customersXmlPath)
		{
			List<Customer> customers = new List<Customer>();

			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(customersXmlPath);

			XmlNodeList customerNodes = xmlDoc.DocumentElement.GetElementsByTagName("Customer");
			foreach (XmlElement customerNode in customerNodes)
			{
				Customer customer = new Customer();
				customer.CustomerId = customerNode.GetAttribute("CustomerID");
				customer.CompanyName = customerNode.GetElementsByTagName("CompanyName")[0].InnerText;
				customer.Country = customerNode.GetElementsByTagName("Country")[0].InnerText;

				customers.Add(customer);
			}

			return customers;
		}

		/// <summary>
		/// Возращает список клиентов прочитанный из указанного XML файла с помощью класса XmlTextReader
		/// </summary>
		/// <param name="customersXmlPath">Путь к файлу customers.xml</param>
		/// <returns>Cписок клиентов</returns>
		/// <remarks>Обратите внимание, что мы всегда возврашаем коллекцию даже если ничего не прочитали из файла</remarks>
		private List<Customer> GetCustomersUsingXmlTextReader(string customersXmlPath)
		{
			List<Customer> customers = new List<Customer>();
			using (XmlTextReader reader = new XmlTextReader(customersXmlPath))
			{
				while (reader.Read())
				{
					if (reader.NodeType == XmlNodeType.Element)
					{
						if (reader.Name == "Customer")
						{
							using (XmlReader innerReader = reader.ReadSubtree())
							{
								if (innerReader.Read())
								{
									Customer customer = new Customer();
									customer.CustomerId = innerReader.GetAttribute("CustomerID");

									innerReader.ReadToFollowing("CompanyName");
									customer.CompanyName = innerReader.ReadElementContentAsString();

									innerReader.ReadToFollowing("Country");
									customer.Country = innerReader.ReadElementContentAsString();

									customers.Add(customer);
								}
							}
						} // if (reader.Name == "Customer")
					} // if (reader.NodeType == XmlNodeType.Element)
				}
			}

			return customers;
		}
	}
}
