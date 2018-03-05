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

namespace TrainingCenter.LessonIO
{
	partial class Program
	{
		private static void BinarySerializationDemo()
		{
			Header("Бинарная сериализация");

			TrainBinary train = new TrainBinary(190.2, 8, "Иванов И.И.", "Петров П.П.", "Сидоров С.С.");

			Comment("Объект до сериализации");
			train.Print();
			Console.WriteLine();

			// Будем работать с файлом в папке для временных файлов
			string tempFileName = Path.Combine(Path.GetTempPath(), "train.dat");
			BinaryFormatter bf = new BinaryFormatter();

			// Выполняем сериализацию
			using (FileStream fs = File.Create(tempFileName))
			{
				bf.Serialize(fs, train);
			}
			Console.WriteLine();

			// Печатаем результат на экран
			Comment("Результат бинарной сериализации");
			using (FileStream fileStream = File.OpenRead(tempFileName))
			{
				PrintToConsole(fileStream);
				Console.WriteLine();
			}

			// Выполняем десериализацию
			using (FileStream fs = File.OpenRead(tempFileName))
			{
				TrainBinary trainCopy = (TrainBinary)bf.Deserialize(fs);
				Comment("Копия объекта после сериализации.");
				trainCopy.Print();
				Console.WriteLine("\r\nReferenceEquals(train, trainCopy)={0}", ReferenceEquals(train, trainCopy));
			}

			Pause();
			
			// Удаляем ненужный временный файл. В настоящем приложении файл может еще понадобиться.
			File.Delete(tempFileName);
		}

		private static void PrintToConsole(FileStream fileStream)
		{
			byte[] buf = new byte[1024];
			int bytesPerLine = Console.WindowWidth / 3, curPos = 0;
			for (; ; )
			{
				int bytesRead = fileStream.Read(buf, 0, buf.Length);
				if (bytesRead == 0) break;

				for (int j = 0; j < bytesRead; curPos++, j++)
				{
					if (curPos >= bytesPerLine)
					{
						Console.WriteLine();
						curPos = 0;
					}
					Console.Write("{0:X2} ", buf[j]);
				}
			}
		}
	}

	// private члены и private типы
	[Serializable]
	class TrainBinary
	{
		// Бинарной сериализацией можно ограниченно управлять с помощью атрибутов
		// Например, NonSerialized запрещает сериализацию поля к которому применяется
		//[NonSerialized]
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
