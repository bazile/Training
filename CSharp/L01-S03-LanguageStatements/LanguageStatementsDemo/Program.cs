using System;

namespace LanguageStatementsDemo
{
	class Program
	{
		static string[] names = new string[] { "Аникей", "Авдотья", "Варфоломей", "Ростислава" };
		static int[] ages = new int[4] { 5, 7, 9, 16 };

		static void Main(string[] args)
		{
			DemoForLoop();
			DemoWhileLoop();
		}

		/// <summary>
		/// Демонстрация работы циклов for/foreach
		/// </summary>
		private static void DemoForLoop()
		{
			// --------------------------------------------------
			// Цикл for

			for (int i = 0; i < names.Length; i++)
			{
				Console.WriteLine(names[i]);
			}
			Console.WriteLine();

			for (int i = 0, j = ages.Length - 1; i < names.Length; i++, j--)
			{
				Console.WriteLine("{0}. {1} лет", names[i], ages[j]);
			}
			Console.WriteLine();

			int k = 0;
			for (;;)
			{
				Console.WriteLine(names[k]);

				k++;
				if (k >= names.Length) break;
			}
			Console.WriteLine();

			// --------------------------------------------------
			// Цикл foreach

			foreach (string name in names)
			{
				Console.WriteLine(name);
			}
		}

		/// <summary>
		/// Демонстрация работы циклов while/do while
		/// </summary>
		private static void DemoWhileLoop()
		{
			int i = 0;
			int maxAge = Int32.MinValue;
			int minAge = Int32.MaxValue;
			while (i < ages.Length)
			{
				if (ages[i] > maxAge) maxAge = ages[i];
				if (ages[i] < minAge) minAge = ages[i];

				i++;
			}
			Console.WriteLine("Максимальный возраст " + maxAge);

			// Задание: выведите максимальный и минимальный возраст в одной строке используя строку с шаблонами подстановки
		}
	}
}
