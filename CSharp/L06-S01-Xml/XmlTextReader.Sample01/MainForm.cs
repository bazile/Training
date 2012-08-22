using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;
using XmlSamples.Shared;

namespace XmlSamples.Sample01
{
	//TODO: correct support of list view grours when they are initially disabled

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
				//customers = GetCustomersUsingXmlReader(customersXmlPath);
				//customers = GetCustomersUsingXmlDocument(customersXmlPath);
				//customers = GetCustomersUsingXmlReader(customersXmlPath, customersXsdPath);
				customers = GetCustomersUsingXmlDocument(customersXmlPath, customersXsdPath);
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

			try
			{
				customersListView.BeginUpdate(); // !!!

				var groupsDict = new Dictionary<string, ListViewGroup>();

				foreach (Customer customer in customers)
				{
					var item = new ListViewItem { Text = customer.CustomerId };  // !!!
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
			finally
			{
				customersListView.EndUpdate();  // !!!
				customersListView.EndUpdate();  // !!!
			}
		}

		/// <summary>
		/// Возвращает список клиентов прочитанный из указанного XML файла с помощью класса XmlDocument
		/// </summary>
		/// <param name="customersXmlPath">Путь к файлу customers.xml</param>
		/// <param name="customersXsdPath">Путь к файлу customers.xsd</param>
		/// <returns>Cписок клиентов</returns>
		/// <remarks>Обратите внимание, что мы всегда возврашаем коллекцию даже если ничего не прочитали из файла</remarks>
		private List<Customer> GetCustomersUsingXmlDocument(string customersXmlPath, string customersXsdPath = null)
		{
			var customers = new List<Customer>();

			var xmlDoc = new XmlDocument();
			xmlDoc.Load(customersXmlPath);
			if (customersXsdPath != null)
			{
				xmlDoc.Schemas.Add("http://tc.belhard.com/2012/Customers", customersXsdPath);
				//xmlDoc.Validate(null);
			}

			XmlNodeList customerNodes = xmlDoc.DocumentElement.GetElementsByTagName("Customer");
			foreach (XmlElement customerNode in customerNodes)
			{
				var customer = new Customer();
				customer.CustomerId = customerNode.GetAttribute("CustomerId");
				customer.CompanyName = customerNode.SelectSingleNode("./CompanyName").InnerText;
				customer.Country = customerNode.SelectSingleNode("./FullAddress/Country").InnerText;

				customers.Add(customer);
			}

			return customers;
		}

		/// <summary>
		/// Возвращает список клиентов прочитанный из указанного XML файла с помощью класса XmlTextReader
		/// </summary>
		/// <param name="customersXmlPath">Путь к файлу customers.xml</param>
		/// <param name="customersXsdPath">Путь к файлу customers.xsd</param>
		/// <returns>Cписок клиентов</returns>
		/// <remarks>Обратите внимание, что мы всегда возврашаем коллекцию даже если ничего не прочитали из файла</remarks>
		private List<Customer> GetCustomersUsingXmlReader(string customersXmlPath, string customersXsdPath = null)
		{
			var customers = new List<Customer>();
			
			XmlReaderSettings readerSettings = null;
			if (customersXsdPath != null)
			{
				readerSettings = new XmlReaderSettings();
				readerSettings.Schemas.Add("http://tc.belhard.com/2012/Customers", customersXsdPath);
				readerSettings.ValidationType = ValidationType.Schema;
			}

			try
			{
				using (var reader = XmlReader.Create(customersXmlPath, readerSettings))
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
										var customer = new Customer();
										customer.CustomerId = innerReader.GetAttribute("CustomerId");

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
			}
			catch(System.Xml.Schema.XmlSchemaValidationException ex)
			{
				throw new CustomerLoadFailedException("Customer.xml has some errors", ex);
			}

			return customers;
		}

	}
}
