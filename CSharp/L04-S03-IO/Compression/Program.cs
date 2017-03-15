/*
 * Демонстрация сжатия данных в .NET 4 с помощью классов DeflateStream и GZipStream
 * 
 */

using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Threading;

namespace TrainingCenter.LessonIO
{
	class Program
	{
		static void Main()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("ru-RU");

			TryCompess(GetExePath(), "Собственный exe файл");

			string textFilePath = Path.Combine(
					Environment.GetFolderPath(Environment.SpecialFolder.Windows)
					, "DirectX.log"
				);
			TryCompess(textFilePath, textFilePath);
		}

		private static void TryCompess(string filePath, string message)
		{
			long originalSize, deflateSize, gzipSize;

			// Пробуем Deflate алгоритм
			using (FileStream inputStream = File.OpenRead(filePath))
			{
				originalSize = inputStream.Length;

				using (MemoryStream outputStream = new MemoryStream())
				{
					using (DeflateStream compressionStream = new DeflateStream(outputStream, CompressionMode.Compress, true))
					{
						inputStream.CopyTo(compressionStream);
					}

					deflateSize = outputStream.Length;
				}
			}

			// Пробуем GZip алгоритм
			using (FileStream inputStream = File.OpenRead(filePath))
			{
				using (MemoryStream outputStream = new MemoryStream())
				{
					using (GZipStream compressionStream = new GZipStream(outputStream, CompressionMode.Compress, true))
					{
						inputStream.CopyTo(compressionStream);
					}

					gzipSize = outputStream.Length;
				}
			}

			long bestSize = Math.Min(deflateSize, gzipSize);

			Console.WriteLine(message);
			Console.WriteLine("Оригинальный размер: {0:N0} байтов", originalSize);
			Report("Алгоритм Deflate   : {0:N0} {1}. Выигрыш {2} {3} ({4:P})", originalSize, deflateSize, bestSize);
			Report("Алгоритм GZip      : {0:N0} {1}. Выигрыш {2} {3} ({4:P})", originalSize, gzipSize, bestSize);
			Console.WriteLine();
		}

		private static void Report(string message, long originalSize, long algoSize, long bestSize)
		{
			ConsoleColor oldColor = Console.ForegroundColor;
			Console.ForegroundColor = algoSize > bestSize ? ConsoleColor.Red : ConsoleColor.Green;
			Console.WriteLine(
				message
				, algoSize
				, algoSize.PrettyBytes()
				, originalSize - algoSize
				, (originalSize - algoSize).PrettyBytes()
				, 1 - (double)algoSize / originalSize
			);
			Console.ForegroundColor = oldColor;
		}

		private static string GetExePath()
		{
			Assembly asm = Assembly.GetExecutingAssembly();

			// Assembly. EscapedCodeBase имеет вид file://c:\SomeFolder\Assembly.dll
			// Используем свойство EscapedCodeBase вместо свойства CodeBase чтобы
			//    символ # (и подобные ему) был бы представлен как %23 и не приводил
			//    к исключению в конструкторе Uri
			// Класс Url позволяет преобразовывать file:// ссылки в локальный путь
			//    с помощью свойства LocalPath
			return new Uri(asm.EscapedCodeBase).LocalPath;
		}
	}
}
