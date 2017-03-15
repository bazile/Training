using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainingCenter.LinqToObjectsDemo
{
    public static class PrimeNumbers
    {
        /// <summary>
        /// Получение последовательности случайных чисел до указанного значения
        /// </summary>
        /// <param name="maxValue"></param>
        public static IEnumerable<int> GetPrimeNumbers(int maxValue)
        {
            if (maxValue == 1) return Enumerable.Empty<int>();
            if (maxValue == 2) return new[] {2};

            Func<int, IEnumerable<int>> primeNumbers = max =>
                 from i in Enumerable.Range(2, max - 1)
                 where Enumerable.Range(2, (int)Math.Sqrt(i)).All(j => i % j != 0)
                 select i;

            return primeNumbers(maxValue);
        }

        /// <summary>
        /// Получение последовательности случайных чисел до указанного значения
        ///     с помощью Parallel LINQ
        /// </summary>
        /// <param name="maxValue"></param>
        public static IEnumerable<int> GetPrimeNumbersParallel(int maxValue)
        {
            if (maxValue == 1) return Enumerable.Empty<int>();
            if (maxValue == 2) return new[] { 2 };

            Func<int, IEnumerable<int>> primeNumbers = max =>
                 from i in Enumerable.Range(2, max - 1).AsParallel()
                 where Enumerable.Range(2, (int)Math.Sqrt(i)).All(j => i % j != 0)
                 select i;

            return primeNumbers(maxValue);
        }
    }
}
