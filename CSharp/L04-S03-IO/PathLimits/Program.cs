/*
 * Демонстрация ограничений на полное имя каталога и файла в .NET
 * 
 * ОС Windows поддерживает пути длиной до 32 Кб, однако в .NET
 *	мы ограничены следующими значениями:
 *		Максимальная длина полного имени каталога – 247 символов
 *		Максимальная длина полного имени файла– 259 символов.
 *	
 * Т.к. Проводник Windows не умеет работать со слишком длинными 
 *	путями, то и нам следует избегать их создания!
 *	
 * Если вам необходимо работать с длинными путями, то используйте
 *	функции Windows API
 *	
 */

using System;
using System.IO;
using System.Linq;

namespace TrainingCenter.LessonIO
{
	class Program
	{
		static void Main()
		{
			// Строим путь к файлу длинной 259 символов
			string[] fileNameParts = new string[8];
			fileNameParts[0] = @"d:\";
			for (int i = 0; i < 5; i++)
			{
				fileNameParts[i + 1] = "abcd-efghij-klmnop-qrstuv-wxyz-0123456789";
			}
			fileNameParts[6] = "0123456789-abcdefghijklmnopqrstuvw";
			fileNameParts[7] = "$$$$$$$.txt"; // Имя файла
			string filePath = Path.Combine(fileNameParts);
			
			// Теперь попробуем создать текстовый файл
			try
			{
				// Сначала пробуем создать каталог
				string dirPath = Path.Combine(fileNameParts.Take(fileNameParts.Length-1).ToArray());
				Console.Write("Пытаемся создать каталог с именем длиной {0} символов", dirPath.Length);
				Directory.CreateDirectory(dirPath);
				Console.WriteLine(". Успех!");

				// Каталог создан. Создаем текстовый файл
				Console.Write("Пытаемся создать файл с именем длиной {0} символов", filePath.Length);
				File.WriteAllText(filePath, "Цыган на цыпочках подходит и цыц цыпленку говорит.");
				Console.WriteLine(". Успех!");

				Console.WriteLine();
				Console.WriteLine("Нажмите [Y] чтобы удалить пробный каталог или другую клавишу для выхода");
				ConsoleKeyInfo key = Console.ReadKey(true);
				if (key.KeyChar == 'y' || key.KeyChar == 'Y')
				{
					DeleteTestDirectory(fileNameParts);
				}
			}
			catch (PathTooLongException)
			{
				Console.WriteLine(". Неудача!");
				
				// Удаляем каталог в случае неудачи
				// Функция Directory.CreateDirectory() создает 
				//	каталоги не проверяю сразу максимальную длину
				//	пути и поэтому на диске может остаться не до
				//	конца созданный каталог
				DeleteTestDirectory(fileNameParts);

				throw;
			}
		}

		private static void DeleteTestDirectory(string[] fileNameParts)
		{
			string rootDir = Path.Combine(fileNameParts[0], fileNameParts[1]);
			if (Directory.Exists(rootDir))
			{
				Directory.Delete(rootDir, true);
			}
		}
	}
}
