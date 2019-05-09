using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace TrainingCenter.LinqToObjectsDemo
{
    class Program
    {
        static void Main()
        {
            int[] arr = { -71, -51, -17, 39, -22, -42, -12, -35, -45, 89, -20, 34, -38, -52, -26, -54, -96, -85, -33, 65, -85, -95, -44, 15, -100 };
            double average1 = 0;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    average1 += arr[i];
                    count++;
                }
            }
            average1 /= count;

            double average2 = arr.Where(n => n > 0).Average();
            Console.WriteLine(average1);
            Console.WriteLine(average2);

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

            //const int maxValue = int.MaxValue / 1000;
            //var seq1 = PrimeNumbers.GetPrimeNumbers(maxValue);
            //var seq2 = PrimeNumbers.GetPrimeNumbersParallel(maxValue);

            //Console.Write("Время без PLINQ: ");
            //Stopwatch watch = Stopwatch.StartNew();
            //int count1 = seq1.Count();
            //watch.Stop();
            //Console.WriteLine(watch.Elapsed);

            //Console.Write("Время  с  PLINQ: ");
            //watch = Stopwatch.StartNew();
            //int count2 = seq2.Count();
            //watch.Stop();
            //Console.WriteLine(watch.Elapsed);

            //if (count1 != count2)
            //{
            //    throw new InvalidOperationException("Кол-во чисел не совпадает. Проверьте алгоритм.");
            //}

            #endregion

            //int[] power2numbers = { 1, 2, 4, 8, 16, 32, 64, 128, 256 };
            //IEnumerable<string> binaryNumbers = from n in power2numbers
            //select Convert.ToString(n, 2)
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

            public override string ToString()
            {
                return string.Format("{0}: {1}", Extension, Count);
            }
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
                string extension = Path.GetExtension(fileName).ToLower();
                if (extCount.ContainsKey(extension))
                {
                    extCount[extension]++;
                }
                else
                {
                    extCount.Add(extension, 1);
                }
            }

            // Копируем данные из Dictionary в массив
            ExtensioInfo[] extensions = new ExtensioInfo[extCount.Count];
            int idx = 0;
            foreach (KeyValuePair<string, int> entry in extCount)
            {
                extensions[idx++] = new ExtensioInfo { Extension = entry.Key, Count = entry.Value };
            }

            // Сортируем
            Array.Sort(
                extensions,
                (inf1, inf2) => inf1.Count != inf2.Count ? inf2.Count - inf1.Count : inf1.Extension.CompareTo(inf2.Extension)
            );

            return extensions;
        }

        static ExtensioInfo[] GetExtensionsUsingLinq(string path)
        {
            return (
                    from fileName in SafeEnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                    group fileName by Path.GetExtension(fileName).ToLower() into ext
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
