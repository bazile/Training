using System;
using System.Xml;
using XmlSamples.Shared;

namespace XmlSamples.Sample02
{
	class Program
	{
		static void Main()
		{
			PrintXml(Util.GetPathToCustomersXml());
		}

		/// <summary>
		/// Вывод содержимое любого XML-документа на экран
		/// </summary>
		/// <param name="xmlPath"></param>
		private static void PrintXml(string xmlPath)
		{
			XmlTextReader xmlReader = new XmlTextReader(xmlPath);
			int spaces = 0; // Количество пробелов перед элементом

			while (xmlReader.Read())
			{
				// Если элемент, то увеличиваем отступ
				if (xmlReader.NodeType == XmlNodeType.Element)
				{
					spaces++;
				}
				if (xmlReader.NodeType != XmlNodeType.Whitespace)
				{
					for (int i = 0; i < spaces; i++)           //Печатаем пробелы
						Console.Write("  ");
					Console.Write(xmlReader.NodeType);             //Печатаем тип узла
					if (xmlReader.Name != "")                      //Печатаем имя
						Console.Write(" - " + xmlReader.Name);
					if (xmlReader.NodeType == XmlNodeType.Text)    //Выводит узел текст
						Console.Write(" - " + xmlReader.Value);
					else if (xmlReader.NodeType == XmlNodeType.Element)    //Если тип узла - элемент
						for (int i = 0; i < xmlReader.AttributeCount; i++) //Выводим все его тарибуты
							Console.Write(" : " + xmlReader.GetAttribute(i));
					Console.WriteLine();
				}
				if (xmlReader.NodeType == XmlNodeType.EndElement || xmlReader.IsEmptyElement)//Если закрывающий тэг
				{
					// Уменьшаем отступ
					spaces--;
				}                                            
			}
		}
	}
}
