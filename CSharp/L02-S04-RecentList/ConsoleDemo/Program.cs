using System;
using System.Collections.Generic;
using System.Linq;

namespace BelhardTraining.RecentListDemo
{
	class Program
	{
		static void Main()
		{
			ShowHelp();

			List<int> x = new List<int>();
			Console.WriteLine(x[0]);

			RecentList<int> list = new RecentList<int>(5);
			bool shownFullMessage = false;
			for (;;)
			{
				Console.WriteLine("Введите число. Для выхода введите пустую строку.");
				Console.Write("> ");
				string line = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(line)) break;

				int num;
				if (!int.TryParse(line, out num)) continue;

				list.Add(num);
				if (list.IsFull && !shownFullMessage)
				{
					ShowFullMessage();
					shownFullMessage = true;
				}

				int[] numbers = list.ToArray();
				Console.WriteLine("{{ {0} }}", string.Join(", ", numbers));
				Console.WriteLine();
			}
		}

		private static void ShowFullMessage()
		{
			ConsoleColor oldColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine();
			Console.WriteLine(" *** Список заполнен до максимума. Новые элементы будут вытеснять старые *** ");
			Console.WriteLine(" ***  При повторном добавлении существующего элемента меняется порядок   *** ");
			Console.WriteLine();
			Console.ForegroundColor = oldColor;
		}

		private static void ShowHelp()
		{
			Console.WriteLine("Демонстрация работы коллекции RecentList<T>.");
			Console.WriteLine("Наблюдайте как меняется порядок элементов в коллекции.");
			Console.WriteLine("Попробуйте вводить разные и одинаковые числа.");
			Console.WriteLine("Максимальный размер списка равен 5.");
			Console.WriteLine();
		}
	}
}
