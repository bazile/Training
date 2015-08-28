using System;
using System.Collections.Generic;
using System.Linq;

namespace BelhardTraining.LinqToObjectsDemo
{
	public static class PrimeNumbers
	{
		/// <summary>
		/// Распечатка последовательности случайных чисел
		/// </summary>
		/// <param name="maxValue"></param>
		public static void PrintPrimeNumbers(int maxValue)
		{
			Func<int, IEnumerable<int>> primeNumbers = max =>
				 from i in Enumerable.Range(2, max - 1)
				 where Enumerable.Range(2, i - 2).All(j => i % j != 0)
				 select i;

			IEnumerable<int> numbers = primeNumbers(maxValue);
			foreach (int num in numbers)
			{
				Console.WriteLine(num);
			}
		}

		/// <summary>
		/// Распечатка последовательности случайных чисел используя
		///     Parallel LINQ
		/// </summary>
		/// <param name="maxValue"></param>
		public static void PrintPrimeNumbersParallel(int maxValue)
		{
			Func<int, IEnumerable<int>> primeNumbers = max =>
				 from i in Enumerable.Range(2, max - 1).AsParallel()
				 where Enumerable.Range(2, i - 2).All(j => i % j != 0)
				 select i;

			IEnumerable<int> numbers = primeNumbers(maxValue);
			foreach (int num in numbers)
			{
				Console.WriteLine(num);
			}
		}
	}
}
