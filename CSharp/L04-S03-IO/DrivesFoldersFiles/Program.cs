/*
 * Демонстрация получения информации о логических дисках,
 *		каталогах и файлах
 * Также демонстрируется получение информации о физических дисках
 *		с помошью WMI (Windows Management Instrumentation)
 *
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management;
using Microsoft.VisualBasic.FileIO;
// В пространствах имен System.IO и Microsoft.VisualBasic.FileIO объявлен enum с именем SearchOption
// Чтобы иметь возможность использовать оба типа, одному из них необходим псевдоним
// В данном случае псевдоним VBSearchOption дается типу Microsoft.VisualBasic.FileIO.SearchOption
using VBSearchOption = Microsoft.VisualBasic.FileIO.SearchOption;

namespace BelhardTraining.LessonIO
{
	class Program
	{
		static void Main()
		{
			#region Получение информации о доступных логических дисках

			PrintAllDrivesInfo();
			//PrintSystemDriveInfo();
			//TryPrintNonExistingDrive();

			#endregion

			#region Получение информации о физических дисках через WMI

			//PrintAllPhysicalDrives();

			#endregion

			#region Поиск каталогов и файлов

			string folder = Environment.GetFolderPath(Environment.SpecialFolder.Programs);

			#region Поиск каталогов и файлов с помощью методов класса Directory

			//// Класс Directory содержит методы:
			////     GetDirectories       - для поиска каталогов
			////     GetFiles			    - для поиска файлов
			////     GetFileSystemEntries - для поиска каталогов и файлов одновременно
			//// Все эти методы имеют одинаковые перегруженные варианты:
			////		1. Путь к папке
			////          Возращаются элементы по маске *.* в указанной папке
			////		2. Путь к папке и маска поиска
			////          Возращаются элементы по маске в указанной папке
			////		3. Путь к папке, маска поиска и enum SearchOption
			////          SearchOption.AllDirectories   = Возращаются элементы по маске в указанной папке включая вложенные
			////          SearchOption.TopDirectoryOnly =	Тоже самое что п.2
			//// Методы возвращают массив строк с полными путями

			//// Примеры для GetDirectories() – поиск каталогов
			//// Все подкаталоги указанного каталога
			//string[] dirs = Directory.GetDirectories(folder);
			//// Подкаталоги по маске «s*» указанного каталога
			//string[] dirsByMask = Directory.GetDirectories(folder, "s*");
			//// Подкаталоги по маске указанного каталога включая вложенные
			//string[] allDirs = Directory.GetDirectories(folder, "s*", SearchOption.TopDirectoryOnly);

			//// Примеры для GetFiles() – поиск файлов
			//// Все файлы в указанном каталоге
			//string[] files = Directory.GetFiles(folder);
			//// Все файлы по маске «*.lnk» в указанном каталоге
			//string[] lnkFiles = Directory.GetFiles(folder, "*.lnk");
			//// Все файлы по маске *.lnk в указанном каталоге включая вложенные
			//string[] allLnkFiles = Directory.GetFiles(folder, "*.lnk", SearchOption.AllDirectories);

			//// Примеры для GetFileSystemEntries() – поиск каталогов и файлов одновременно
			//// Имейте в виду что каталоги и файлы будут идти вперемешку!
			//// Все каталоги м файлы в указанном каталоге
			//string[] filesAndDirs = Directory.GetFileSystemEntries(folder);
			//// Все файлы и каталоги по маске «*t*» в указанном каталоге
			//string[] filesAndDirsByMask = Directory.GetFileSystemEntries(folder, "*t*");
			//// Все файлы и каталоги по маске «*t*» в указанном каталоге включая вложенные
			//string[] allFilesAndDirs = Directory.GetFileSystemEntries(folder, "*t*", SearchOption.AllDirectories);

			#endregion

			#region Поиск каталогов и файлов с помощью методов класса DirectoryInfo

			//// Класс DirectoryInfo содержит методы:
			////     GetDirectories     - для поиска каталогов
			////     GetFiles			  - для поиска файлов
			////     GetFileSystemInfos - для поиска каталогов и файлов одновременно
			//// Все эти методы имеют одинаковые перегруженные варианты:
			////		1. Без аргументов
			////          Возращаются элементы по маске *.* в папке
			////		2. Маска поиска
			////          Возращаются элементы по маске в папке
			////		3. Маска поиска и enum SearchOption
			////          SearchOption.AllDirectories   = Возращаются элементы по маске в папке включая вложенные
			////          SearchOption.TopDirectoryOnly =	Тоже самое что п.2
			//// Методы возвращают массив строк с полными путями

			//DirectoryInfo dirInfo = new DirectoryInfo(folder);

			//// Каталоги
			//DirectoryInfo[] dirs = dirInfo.GetDirectories();
			//DirectoryInfo[] dirsByMask = dirInfo.GetDirectories("s*");
			//DirectoryInfo[] allDirs = dirInfo.GetDirectories("s*", SearchOption.AllDirectories);

			//// Файлы
			//FileInfo[] files = dirInfo.GetFiles();
			//FileInfo[] lnkFiles = dirInfo.GetFiles("*.lnk");
			//FileInfo[] allLnkFiles = dirInfo.GetFiles("*.lnk", SearchOption.AllDirectories);

			//// Каталоги и файлы
			//FileSystemInfo[] filesAndDirs = dirInfo.GetFileSystemInfos();
			//FileSystemInfo[] filesAndDirsByMask = dirInfo.GetFileSystemInfos("*t*");
			//FileSystemInfo[] allFilesAndDirs = dirInfo.GetFileSystemInfos("*t*", SearchOption.AllDirectories);

			#endregion

			#region Поиск каталогов и файлов "по одному" с помощью EnumerateXYZ методов класса Directory

			//// Класс Directory содержит методы:
			////     EnumerateDirectories       - для поиска каталогов
			////     EnumerateFiles			  - для поиска файлов
			////     EnumerateFileSystemEntries - для поиска каталогов и файлов одновременно
			//// Все эти методы имеют одинаковые перегруженные варианты:
			////		1. Путь к папке
			////          Возращаются элементы по маске *.* в указанной папке
			////		2. Путь к папке и маска поиска
			////          Возращаются элементы по маске в указанной папке
			////		3. Путь к папке, маска поиска и enum SearchOption
			////          SearchOption.AllDirectories   = Возращаются элементы по маске в указанной папке включая вложенные
			////          SearchOption.TopDirectoryOnly =	Тоже самое что п.2
			//// Методы возвращают IEnumerable<string> с полными путями
			//// Достоинство этих методов что они не требуют выделения памяти под все имена файлов сразу
			////	и поэтому могут оказаться более эффективными для больших списков

			//// Примеры для GetDirectories() – поиск каталогов
			//// Все подкаталоги указанного каталога
			//IEnumerable<string> dirs = Directory.EnumerateDirectories(folder);
			//// Подкаталоги по маске «s*» указанного каталога
			//IEnumerable<string> dirsByMask = Directory.EnumerateDirectories(folder, "s*");
			//// Подкаталоги по маске указанного каталога включая вложенные
			//IEnumerable<string> allDirs = Directory.EnumerateDirectories(folder, "s*", SearchOption.TopDirectoryOnly);

			//// Примеры для GetFiles() – поиск файлов
			//// Все файлы в указанном каталоге
			//IEnumerable<string> files = Directory.EnumerateFiles(folder);
			//// Все файлы по маске «*.lnk» в указанном каталоге
			//IEnumerable<string> lnkFiles = Directory.EnumerateFiles(folder, "*.lnk");
			//// Все файлы по маске *.lnk в указанном каталоге включая вложенные
			//IEnumerable<string> allLnkFiles = Directory.EnumerateFiles(folder, "*.lnk", SearchOption.AllDirectories);

			//// Примеры для GetFileSystemEntries() – поиск каталогов и файлов одновременно
			//// Имейте в виду что каталоги и файлы будут идти вперемешку!
			//// Все каталоги м файлы в указанном каталоге
			//IEnumerable<string> filesAndDirs = Directory.EnumerateFileSystemEntries(folder);
			//// Все файлы и каталоги по маске «*t*» в указанном каталоге
			//IEnumerable<string> filesAndDirsByMask = Directory.EnumerateFileSystemEntries(folder, "*t*");
			//// Все файлы и каталоги по маске «*t*» в указанном каталоге включая вложенные
			//IEnumerable<string> allFilesAndDirs = Directory.EnumerateFileSystemEntries(folder, "*t*", SearchOption.AllDirectories);

			#endregion

			#region Поиск каталогов и файлов "по одному" с помощью EnumerateXYZ методов класса DirectoryInfo

			//// Класс DirectoryInfo содержит методы:
			////     EnumerateDirectories     - для поиска каталогов
			////     EnumerateFiles			  - для поиска файлов
			////     EnumerateFileSystemInfos - для поиска каталогов и файлов одновременно
			//// Все эти методы имеют одинаковые перегруженные варианты:
			////		1. Без аргументов
			////          Возращаются элементы по маске *.* в папке
			////		2. Маска поиска
			////          Возращаются элементы по маске в папке
			////		3. Маска поиска и enum SearchOption
			////          SearchOption.AllDirectories   = Возращаются элементы по маске в папке включая вложенные
			////          SearchOption.TopDirectoryOnly =	Тоже самое что п.2
			//// Методы возвращают IEnumerable<DirectoryInfo>, IEnumerable<FileInfo> или IEnumerable<FileSystemInfo>
			//// Достоинство этих методов что они не требуют выделения памяти под все имена файлов сразу
			////	и поэтому могут оказаться более эффективными для больших списков

			//DirectoryInfo dirInfo = new DirectoryInfo(folder);

			//// Каталоги
			//IEnumerable<DirectoryInfo> dirs = dirInfo.EnumerateDirectories();
			//IEnumerable<DirectoryInfo> dirsByMask = dirInfo.EnumerateDirectories("s*");
			//IEnumerable<DirectoryInfo> allDirs = dirInfo.EnumerateDirectories("s*", SearchOption.AllDirectories);

			//// Файлы
			//IEnumerable<FileInfo> files = dirInfo.EnumerateFiles();
			//IEnumerable<FileInfo> lnkFiles = dirInfo.EnumerateFiles("*.lnk");
			//IEnumerable<FileInfo> allLnkFiles = dirInfo.EnumerateFiles("*.lnk", SearchOption.AllDirectories);

			//// Каталоги и файлы
			//IEnumerable<FileSystemInfo> filesAndDirs = dirInfo.EnumerateFileSystemInfos();
			//IEnumerable<FileSystemInfo> filesAndDirsByMask = dirInfo.EnumerateFileSystemInfos("*t*");
			//IEnumerable<FileSystemInfo> allFilesAndDirs = dirInfo.EnumerateFileSystemInfos("*t*", SearchOption.AllDirectories);

			#endregion

			#region Поиск с помощью нескольких шаблонов. Класс Microsoft.VisualBasic.FileIO.FileSystem

			//ReadOnlyCollection<string> dirs = FileSystem.GetDirectories(folder, VBSearchOption.SearchTopLevelOnly, "*.*");
			//ReadOnlyCollection<string> dirsByMask = FileSystem.GetDirectories(folder, VBSearchOption.SearchTopLevelOnly, "A*", "S*");
			//ReadOnlyCollection<string> allDirs = FileSystem.GetDirectories(folder, VBSearchOption.SearchAllSubDirectories, "A*", "S*");

			//ReadOnlyCollection<string> files = FileSystem.GetFiles(folder, VBSearchOption.SearchTopLevelOnly, "*.*");
			//ReadOnlyCollection<string> filesByMask = FileSystem.GetFiles(folder, VBSearchOption.SearchTopLevelOnly, "*.lnk", "*.txt");
			//ReadOnlyCollection<string> allFiles = FileSystem.GetFiles(folder, VBSearchOption.SearchAllSubDirectories, "*.lnk", "*.ini");

			#endregion

			#endregion
		}

		#region Получение информации о доступных логических дисках

		/// <summary>
		/// Демонстрация получения информации о доступных логических дисках
		/// </summary>
		static void PrintAllDrivesInfo()
		{
			DriveInfo[] drives = DriveInfo.GetDrives();
			bool first = true;
			foreach (DriveInfo driveInfo in drives)
			{
				PrintDriveInfo(driveInfo, !first);
				first = false;
			}
		}
		
		/// <summary>
		/// Демонстрация получения информации о конкретном диске
		/// В данном случае системном. Обычно это C:
		/// </summary>
		private static void PrintSystemDriveInfo()
		{
			string systemDrive = Environment.GetEnvironmentVariable("SYSTEMDRIVE");
			if (systemDrive != null)
			{
				DriveInfo systemDriveInfo = new DriveInfo(systemDrive);
				PrintDriveInfo(systemDriveInfo, false);
			}
		}

		/// <summary>
		/// Демонстрация получения информации о несуществующем диске
		/// В этом случае можно читать только свойства Name и DriveType
		/// При этом DriveType = NoRootDirectory
		/// </summary>
		static void TryPrintNonExistingDrive()
		{
			// Формируем массив букв используемых дисков
			char[] usedLetters = DriveInfo.GetDrives().Select(d => d.Name[0]).OrderBy(ch => ch).ToArray();
			// Формируем массив английских букв от C до Z
			// Для это пользуемся тем фактом что в кодировке UTF-16 они идут друг за другом
			char[] lettersFromC = Enumerable.Range(0, 24).Select(i => ((char)('C' + i))).ToArray();
			// Получаем первую незанятую букву диска, если она есть
			char firstUnusedLetter = lettersFromC.Except(usedLetters).FirstOrDefault();
			if (firstUnusedLetter == '\0')
			{
				Console.WriteLine("На данном компьютере заняты все буквы дисков!");
			}
			else
			{
				DriveInfo nonExistingDrive = new DriveInfo(firstUnusedLetter + ":");
				Console.WriteLine(
					"Диск {0} не существует. Его тип: {1}",
					nonExistingDrive.Name, nonExistingDrive.DriveType
				);
			}
		}

		static void PrintDriveInfo(DriveInfo driveInfo, bool printSeparator)
		{
			if (printSeparator)
			{
				Console.WriteLine("---------------------------------");
			}

			// Тип диска (enum): Fixed (HDD/SSD), CDRom (CD/DVD,BluRay), Removable (флешка), Network и т.д.
			Console.WriteLine("Тип диска       : {0}", driveInfo.DriveType);
			// Имя: C:\, D:\, ...
			Console.WriteLine("Имя             : {0}", driveInfo.Name);
			if (driveInfo.IsReady)
			{
				// Файловая система (строка): NTFS, FAT32, exFAT, ...
				Console.WriteLine("Файловая система: {0}", driveInfo.DriveFormat);
				Console.WriteLine("Готов?          : {0}", driveInfo.IsReady);
				Console.WriteLine("Корень          : {0}", driveInfo.RootDirectory);
				Console.WriteLine("Свободное место : {0:N0} {1}", driveInfo.TotalFreeSpace, driveInfo.TotalFreeSpace.PrettyBytes());
				Console.WriteLine("Размер          : {0:N0} {1}", driveInfo.TotalSize, driveInfo.TotalSize.PrettyBytes());
				Console.WriteLine("Метка диска     : {0}", driveInfo.VolumeLabel);
			}
		}

		#endregion

		#region Получение информации о физических дисках через WMI

		/// <summary>
		/// Печатаем часть информации о физических дисках с помощью WMI классов:
		///		* Win32_FloppyDrive - флоппи-диски
		///		* Win32_DiskDrive - внутренние и внешние диски. Также флэшки.
		///		* Win32_CDROMDrive - оптические диски
		/// </summary>
		/// <remarks>
		/// Полный список WMI классов есть в MSDN
		/// http://msdn.microsoft.com/en-us/library/aa394554%28v=vs.85%29.aspx
		/// </remarks>
		static void PrintAllPhysicalDrives()
		{
			Console.WriteLine("Список локальных дисков");
			Console.WriteLine("=======================");
			using (ManagementClass mc = new ManagementClass("Win32_DiskDrive"))
			{
				ManagementObjectCollection x = mc.GetInstances();
				if (x.Count == 0)
				{
					Console.WriteLine(" * Ни одного не найдено");
				}
				else
				{
					foreach (ManagementObject mo in x)
					{
						Console.WriteLine(" * {0}", GetWmiValue(mo, "Caption"));
						Console.WriteLine("\tРазмер         : {0}", GetWmiValue(mo, "Size"));
						Console.WriteLine("\tКол-во разделов: {0}", GetWmiValue(mo, "Partitions"));
						Console.WriteLine("\tСерийный номер : {0}", GetWmiValue(mo, "SerialNumber"));
					}
				}
			}
			Console.WriteLine();

			Console.WriteLine("Список оптических дисков");
			Console.WriteLine("========================");
			using (ManagementClass mc = new ManagementClass("Win32_CDROMDrive"))
			{
				ManagementObjectCollection x = mc.GetInstances();
				if (x.Count == 0)
				{
					Console.WriteLine(" * Ни одного не найдено");
					Console.WriteLine();
				}
				else
				{
					foreach (ManagementObject mo in x)
					{
						Console.WriteLine(" * {0} ==> {1}", GetWmiValue(mo, "Drive"), GetWmiValue(mo, "Name"));
					}
				}
			}
			Console.WriteLine();

			Console.WriteLine("Список floppy дисков");
			Console.WriteLine("====================");
			using (ManagementClass mc = new ManagementClass("Win32_FloppyDrive"))
			{
				ManagementObjectCollection x = mc.GetInstances();
				if (x.Count == 0)
				{
					Console.WriteLine(" * Ни одного не найдено");
					Console.WriteLine();
				}
				else
				{
					foreach (ManagementObject mo in x)
					{
						Console.WriteLine(" * {0}", GetWmiValue(mo, "Caption"));
						Console.WriteLine("\tМаксимальный размер: {0}", GetWmiValue(mo, "MaxMediaSize"));
					}
				}
			}

		}

		static string GetWmiValue(ManagementObject manObj, string propertyName)
		{
			object result = manObj[propertyName];
			return result == null ? "" : result.ToString();
		}
		
		#endregion
	}
}

/*
			//string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
			//DirectoryInfo programFilesInfo = new DirectoryInfo(programFiles);
			//DirectorySecurity programFilesAcl = programFilesInfo.GetAccessControl();
			//foreach (FileSystemAccessRule rule in programFilesAcl.GetAccessRules(true, true, typeof(NTAccount)))
			//{
			//    Console.WriteLine(rule.AccessControlType);
			//    Console.WriteLine(rule.FileSystemRights);
			//    Console.WriteLine(rule.IdentityReference.Value);
			//    Console.WriteLine(rule.InheritanceFlags);
			//    Console.WriteLine(rule.IsInherited);
			//    Console.WriteLine(rule.PropagationFlags);
			//    Console.WriteLine();
			//}
*/
