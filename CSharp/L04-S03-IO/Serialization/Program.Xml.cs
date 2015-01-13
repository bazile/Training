/*
 * Демонстрация XML сериализации
 * 
 * XML серилизация умеет работать только с public полями и
 *	свойствами. В результате мы получаем текст в формате XML
 *	которым можно обмениваться между приложениями написанными
 *	на разных языках и работающих под разными ОС.
 *	
 * Мы можем влиять на результат сериализаци с помощью атрибутов
 *	из пространства имен System.Xml.Serialization
 *	
 */

using System;
using System.IO;
using System.Xml.Serialization;

namespace BelhardTraining.LessonIO
{
	partial class Program
	{
		private static void XmlSerializationDemo()
		{
			Header("XML сериализация");

			TrainXml train = new TrainXml(190.2, 8, "Иванов И.И.", "Петров П.П.", "Сидоров С.С.");
			Comment("Объект до сериализации");
			train.Print();
			Console.WriteLine();

			using (MemoryStream memoryStream = new MemoryStream())
			{
				// Выполняем сериализацию в поток в памяти
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(TrainXml));
				xmlSerializer.Serialize(memoryStream, train);

				// Печатаем результат на экран
				memoryStream.Position = 0;
				StreamReader reader = new StreamReader(memoryStream);
				string xml = reader.ReadToEnd();
				Comment("Результат XML сериализации");
				Console.WriteLine(xml);
				Console.WriteLine();
				memoryStream.Position = 0;

				// Выполняем десериализацию
				TrainXml trainCopy = (TrainXml)xmlSerializer.Deserialize(memoryStream);
				Comment("Копия объекта после сериализации.");
				trainCopy.Print();
				Console.WriteLine("\r\nReferenceEquals(train, trainCopy)={0}", ReferenceEquals(train, trainCopy));

				reader.Close();
			}

			Pause();
		}
	}

	// Для XML сериализации важно чтобы тип был public
	public class TrainXml
	{
		// Xml-сериализацией можно управлять с помощью атрибутов
		// Например, XmlIgnore запрещает сериализацию свойства к которому применяется
		//[XmlIgnore]
		public double Speed { get; set; }

		public int Length { get; set; }

		[XmlArrayItem("Pax")]
		public string[] Travellers { get; set; }

		// Для XML сериализации требуется наличие конструктора без аргументов
		public TrainXml()
		{
		}

		public TrainXml(double speed, int length, params string[] travellers)
		{
			Speed = speed;
			Length = length;
			Travellers = travellers;
		}

		public void Print()
		{
			Console.WriteLine("Скорость      : {0}", Speed);
			Console.WriteLine("Кол-ва вагонов: {0}", Length);
			Console.WriteLine("Пассажиры     : {0}", String.Join("; ", Travellers));
		}
	}
}
