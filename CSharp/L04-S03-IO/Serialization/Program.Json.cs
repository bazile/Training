/*
 * Демонстрация JSON сериализации
 * 
 * JSON - компактный текстовый формат из мира веб разработки.
 * Расшифровывается как Java Script Object Notation
 *	
 */

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

// TODO: Json.NET demo
// TDOD: https://jsonclassgenerator.codeplex.com/

namespace BelhardTraining.LessonIO
{
	partial class Program
	{
		private static void JsonSerializationDemo()
		{
			Header("JSON сериализация");

			TrainJson train = new TrainJson{ Speed = 190.2, Length = 8, Travellers = new[] {"Иванов И.И.", "Петров П.П.", "Сидоров С.С."}};
			Comment("Объект до сериализации");
			train.Print();
			Console.WriteLine();

			using (MemoryStream memoryStream = new MemoryStream())
			{
				// Выполняем сериализацию в поток в памяти
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(TrainJson));
				serializer.WriteObject(memoryStream, train);

				// Печатаем результат на экран
				memoryStream.Position = 0;
				StreamReader reader = new StreamReader(memoryStream);
				string json = reader.ReadToEnd();
				Comment("Результат JSON сериализации");
				Console.WriteLine(json);
				Console.WriteLine();
				memoryStream.Position = 0;

				// Выполняем десериализацию
				TrainJson trainCopy = (TrainJson)serializer.ReadObject(memoryStream);
				Comment("Копия объекта после сериализации.");
				trainCopy.Print();
				Console.WriteLine("\r\nReferenceEquals(train, trainCopy)={0}", ReferenceEquals(train, trainCopy));

				reader.Close();
			}

			Pause();
		}
	}

	// private члены и private типы
	[DataContract]
	class TrainJson
	{
		// JSON-сериализацией можно управлять с помощью атрибутов
		// Например, отсутствие DataMember приведет к игнорированию данного члена класса
		[DataMember]
		internal double Speed;

		[DataMember]
		internal int Length;

		[DataMember]
		internal string[] Travellers;

		public void Print()
		{
			Console.WriteLine("Скорость      : {0}", Speed);
			Console.WriteLine("Кол-ва вагонов: {0}", Length);
			Console.WriteLine("Пассажиры     : {0}", String.Join("; ", Travellers));
		}
	}
}
