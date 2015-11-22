using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace BelhardTraining.LinqToObjectsDemo
{
	class Program
	{
		static void Main()
		{
			#region Поиск файлов без LINQ и с ним

			//string mydocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			//ExtensioInfo[] extensions1 = GetExtensions(mydocuments);
			//ExtensioInfo[] extensions2 = GetExtensionsUsingLinq(mydocuments);
			//foreach (ExtensioInfo extensioInfo in extensions1)
			//{
			//    Console.WriteLine("{0} - {1}", extensioInfo.Count.ToString().PadRight(4), extensioInfo.Extension);
			//}
			//Console.WriteLine();

			//// Убеждаемся что последовательности совпадают
			//bool resultsAreEqual = extensions1.SequenceEqual(extensions2, new ExtensioInfoEqualityComparer());
			//if (resultsAreEqual)
			//{
			//    WriteColorLine(ConsoleColor.Green, "Ура! Результат работы функций c LINQ и без него совпадают!");
			//}
			//else
			//{
			//    // Такого быть не должно!
			//    WriteColorLine(ConsoleColor.Red, "Результат работы функций c LINQ и без него не совпадают! :(");
			//}

			#endregion

			#region Простые числа

			//const int maxValue = int.MaxValue/10000;
			//var seq1 = PrimeNumbers.PrintPrimeNumbers(maxValue);
			//var seq2 = PrimeNumbers.PrintPrimeNumbersParallel(maxValue);
			//Stopwatch watch = Stopwatch.StartNew();
			//int count1 = seq1.Count();
			//watch.Stop();
			//Console.WriteLine("Время без PLINQ: {0}", watch.Elapsed);
			//watch = Stopwatch.StartNew();
			//int count2 = seq2.Count();
			//watch.Stop();
			//Console.WriteLine("Время  с  PLINQ: {0}", watch.Elapsed);

			//if (count1 != count2)
			//{
			//    throw new InvalidOperationException("Кол-во чисел не совпадает. Проверьте алгоритм.");
			//}

			#endregion
		}

		static void WriteColorLine(ConsoleColor foregroundColor, string message)
		{
			ConsoleColor oldColor = Console.ForegroundColor;
			Console.ForegroundColor = foregroundColor;
			Console.WriteLine(message);
			Console.ForegroundColor = oldColor;
		}

		#region Поиск файлов без LINQ и с ним

		class ExtensioInfo
		{
			public string Extension;
			public int Count;
		}

		class ExtensioInfoEqualityComparer : IEqualityComparer<ExtensioInfo>
		{
			public bool Equals(ExtensioInfo a, ExtensioInfo b)
			{
				return a.Count == b.Count && a.Extension == b.Extension;
			}

			public int GetHashCode(ExtensioInfo info)
			{
				return info.Count.GetHashCode() ^ info.Extension.GetHashCode();
			}
		}

		static ExtensioInfo[] GetExtensions(string path)
		{
			// Собираем информацию о файлах
			var extCount = new Dictionary<string, int>();
			foreach (string fileName in SafeEnumerateFiles(path, "*.*", SearchOption.AllDirectories))
			{
				string extension = Path.GetExtension(fileName).ToLowerInvariant();
				if (extCount.ContainsKey(extension))
				{
					extCount[extension]++;
				}
				else
				{
					extCount.Add(extension, 1);
				}
			}

			// Копируем данные из хеш таблицы в массив и сортируем его
			ExtensioInfo[] extensions = new ExtensioInfo[extCount.Count];
			int idx = 0;
			foreach (KeyValuePair<string, int> entry in extCount)
			{
				extensions[idx++] = new ExtensioInfo { Extension = entry.Key, Count = entry.Value };
			}
			Array.Sort(
				extensions,
				(inf1, inf2) => inf2.Count - inf1.Count != 0 ? inf2.Count - inf1.Count : inf1.Extension.CompareTo(inf2.Extension)
			);

			return extensions;
		}

		static ExtensioInfo[] GetExtensionsUsingLinq(string path)
		{
			return (
					from fileName in SafeEnumerateFiles(path, "*.*", SearchOption.AllDirectories)
					group fileName by Path.GetExtension(fileName).ToLowerInvariant() into ext
					orderby ext.Count() descending, ext.Key
					select new ExtensioInfo { Extension = ext.Key, Count = ext.Count() }
				).ToArray();
		}

		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="path">Путь</param>
		/// <param name="searchPattern">Маска поиска для файлов</param>
		/// <param name="searchOption"></param>
		/// <returns></returns>
		private static IEnumerable<string> SafeEnumerateFiles(string path, string searchPattern, SearchOption searchOption)
		{
			Stack<string> dirs = new Stack<string>();

			//if (!Directory.Exists(path))
			//{
			//    throw new DirectoryNotFoundException();
			//}
			dirs.Push(path);

			while (dirs.Count > 0)
			{
				string currentDirPath = dirs.Pop();
				if (searchOption == SearchOption.AllDirectories)
				{
					try
					{
						string[] subDirs = Directory.GetDirectories(currentDirPath);
						foreach (string subDirPath in subDirs)
						{
							dirs.Push(subDirPath);
						}
					}
					catch (UnauthorizedAccessException)
					{
						continue;
					}
					catch (DirectoryNotFoundException)
					{
						continue;
					}
				}

				string[] files;
				try
				{
					files = Directory.GetFiles(currentDirPath, searchPattern);
				}
				catch (UnauthorizedAccessException)
				{
					continue;
				}
				catch (DirectoryNotFoundException)
				{
					continue;
				}

				foreach (string filePath in files)
				{
					yield return filePath;
				}
			}
		}

		#endregion
	}
}
