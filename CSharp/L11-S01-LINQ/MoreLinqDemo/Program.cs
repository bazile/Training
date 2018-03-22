using System;
using System.Linq;
using System.Text;
using MoreLinq;

//
// Демонстрация методов из библиотеки MoreLINQ
// https://www.nuget.org/packages/morelinq
//

namespace TrainingCenter.MoreLinqDemo
{
	class Program
	{
		static void Main()
		{
			Console.WriteLine(string.Join("\n", typeof(MoreEnumerable).GetMethods().Select(mi => mi.Name).Distinct().OrderBy(s => s)));
			return;

			#region Метод Batch

			// Метод Batch возвращает данные из коллекции в виде пакета (batch) указанного размера

			// Строка cipherText была зашифрована путем перестановки пар символов
			string cipherText = "еНч дуСеоН ,енп ерркСаоН , ажуСаоНи о апНС Оубвк уТ« »ипасьтн паарНСо";
			// Выбираем пары символов с помощью метода Batch, меняем их местами
			//	и делаем из них общую последовательность с помощью SelectMany
			var chars = cipherText.Batch(2).SelectMany(pair => pair.Reverse());
			string text = string.Join("", chars);

			Console.OutputEncoding = Encoding.UTF8;
			Console.WriteLine(text);

			#endregion
		}
	}
}
