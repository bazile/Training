/*
 * Демонстрация бинарной сериализации
 * 
 * Бинарная серилизация самая мощная т.к. умеет работать с private
 *	полями класса. Однако она переносима только между .NET 
 *	приложениями
 *	
 * Тип поддерживающий бинарную сериализацю должен быть помечен
 *	атрибутом [Serializable]
 *	
 */

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BelhardTraining.LessonIO
{
	partial class Program
	{
		private static void BinarySerializationDemo()
		{
			Header("Бинарная сериализация");

			TrainBinary train = new TrainBinary(190.2, 8, "Иванов И.И.", "Петров П.П.", "Сидоров С.С.");

			Comment("Объект до сериализации");
			train.Print();

			// Будем работать с файлом в папке для временных файлов
			string tempFileName = Path.Combine(Path.GetTempPath(), "train.dat");
			BinaryFormatter bf = new BinaryFormatter();
			// Выполняем сериализацию
			using (FileStream fs = File.Open(tempFileName, FileMode.Create))
			{
				bf.Serialize(fs, train);
			}
			Console.WriteLine();
			// Выполняем десериализацию
			using (FileStream fs = File.Open(tempFileName, FileMode.Open))
			{
				TrainBinary someTrain = (TrainBinary)bf.Deserialize(fs);
				Comment("Копия объекта после сериализации.");
				someTrain.Print();
			}
			// Удаляем ненужный временный файл. В настоящем приложении файл может еще понадобиться.
			File.Delete(tempFileName);

			Pause();
		}
	}

	// private члены и private типы
	[Serializable]
	class TrainBinary
	{
		[NonSerialized]
		private double speed;
		private int length;
		private string[] travellers;

		public TrainBinary(double speed, int length, params string[] travellers)
		{
			this.speed = speed;
			this.length = length;
			this.travellers = travellers;
		}
		public void Print()
		{
			Console.WriteLine("Скорость      : {0}", speed);
			Console.WriteLine("Кол-ва вагонов: {0}", length);
			Console.WriteLine("Пассажиры     : {0}", String.Join("; ", travellers));
		}
	}
}
