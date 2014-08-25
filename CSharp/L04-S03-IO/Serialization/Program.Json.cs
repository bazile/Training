/*
 * Демонстрация JSON сериализации
 * 
 * JSON - компактный текстовый формат из мира веб разработки.
 *	
 */
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Serialization
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

				// Печатаем реузльтат на экран
				memoryStream.Position = 0;
				StreamReader reader = new StreamReader(memoryStream);
				string json = reader.ReadToEnd();
				Comment("Результат JSON сериализации");
				Console.WriteLine(json);
				Console.WriteLine();
				memoryStream.Position = 0;

				// Выполняем десериализацию
				TrainJson someTrain = (TrainJson)serializer.ReadObject(memoryStream);
				Comment("Копия объекта после сериализации.");
				someTrain.Print();

				reader.Close();
			}

			Pause();
		}
	}

	// private члены и private типы
	[DataContract]
	class TrainJson
	{
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
