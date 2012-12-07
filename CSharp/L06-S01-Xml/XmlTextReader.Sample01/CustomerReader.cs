using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;

namespace XmlSamples.Sample01
{
	internal static class CustomerReader
	{
		private const string CUSTOMERS_NAMESPACE = "http://tc.belhard.com/2012/Customers";

		/// <summary>
		/// Возвращает список клиентов прочитанный из указанного XML файла с помощью класса XmlDocument
		/// </summary>
		/// <param name="customersXmlPath">Путь к файлу customers.xml</param>
		/// <param name="customersXsdPath">Путь к файлу customers.xsd</param>
		/// <returns>Cписок клиентов</returns>
		/// <remarks>Обратите внимание, что мы всегда возврашаем коллекцию даже если ничего не прочитали из файла</remarks>
		/// <exception cref="InvalidCustomerFileException">Входной файл не соответствует XML схеме</exception>
		public static List<Customer> GetCustomersUsingXmlDocument(string customersXmlPath, string customersXsdPath = null)
		{
			var customers = new List<Customer>();

			var xmlDoc = new XmlDocument();
			xmlDoc.Load(customersXmlPath);
			if (customersXsdPath != null)
			{
				xmlDoc.Schemas.Add(CUSTOMERS_NAMESPACE, customersXsdPath);

				try
				{
					xmlDoc.Validate(null);
				}
				catch (XmlSchemaValidationException ex)
				{
					throw new InvalidCustomerFileException("Customer.xml has some errors", ex);
				}
			}

			var nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
			nsmgr.AddNamespace("c", CUSTOMERS_NAMESPACE);

			XmlNodeList customerNodes = xmlDoc.DocumentElement.SelectNodes("c:Customer", nsmgr);
			foreach (XmlElement customerNode in customerNodes)
			{
				var customer = new Customer { CustomerId = customerNode.GetAttribute("CustomerId") };

				XmlNode companyNameNode = customerNode.SelectSingleNode("c:CompanyName", nsmgr);
				if (companyNameNode != null)
				{
					customer.CompanyName = companyNameNode.InnerText;
				}

				XmlNode countryNode = customerNode.SelectSingleNode("c:FullAddress/c:Country", nsmgr);
				if (countryNode != null)
				{
					customer.Country = countryNode.InnerText;
				}

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
		/// <exception cref="InvalidCustomerFileException">Входной файл не соответствует XML схеме</exception>
		public static List<Customer> GetCustomersUsingXmlReader(string customersXmlPath, string customersXsdPath = null)
		{
			var customers = new List<Customer>();
			
			XmlReaderSettings readerSettings = null;
			if (customersXsdPath != null)
			{
				readerSettings = new XmlReaderSettings();
				readerSettings.Schemas.Add(CUSTOMERS_NAMESPACE, customersXsdPath);
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
			catch(XmlSchemaValidationException ex)
			{
				throw new InvalidCustomerFileException("Customer.xml has some errors", ex);
			}

			return customers;
		}
	}
}