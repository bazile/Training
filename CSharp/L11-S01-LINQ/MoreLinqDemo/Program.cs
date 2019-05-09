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
            //Console.WriteLine(string.Join("\n", typeof(MoreEnumerable).GetMethods().Select(mi => mi.Name).Distinct().OrderBy(s => s)));
            //return;

            // Acquire - Ensures that a source sequence of System.IDisposable objects are all acquired successfully
            // AggregateRight - Applies a right-associative accumulator function over a sequence
            // Append - Returns a sequence consisting of the head elements and the given tail element
            // Assert - Asserts that all elements of a sequence meet a given condition otherwise throws an System.Exception object
            // AssertCount - Asserts that a source sequence contains a given count of elements. A parameter specifies the exception to be thrown.
            // AtLeast - Determines whether or not the number of elements in the sequence is greater than or equal to the given integer
            // AtMost - Determines whether or not the number of elements in the sequence is lesser than or equal to the given integer
            // Backsert - Inserts the elements of a sequence into another sequence at a specified index from the tail of the sequence
            // Batch - возвращает данные из коллекции в виде пакета (batch) указанного размера
            // Cartesian - Returns the Cartesian product of N (2 to 8) sequences
            // Choose - Applies a function to each element of the source sequence and returns a new sequence of result elements for source elements where the function returns a couple (2-tuple) having a true as its first element and result as the second
            // Pipe - Executes the given action on each element in the source sequence and yields it
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
