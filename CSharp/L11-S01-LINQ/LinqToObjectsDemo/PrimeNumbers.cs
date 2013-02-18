using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToObjectsDemo
{
	static class PrimeNumbers
	{
		internal static void PrintPrimeNumbers(int maxValue)
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

		internal static void PrintPrimeNumbersParallel(int maxValue)
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
