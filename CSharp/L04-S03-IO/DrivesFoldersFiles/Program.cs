/*
 * Демонстрация получения информации о логических дисках,
 *		каталогах и файлах
 * Также демонстрируется получение информации о физических дисках
 *		с помошью WMI (Windows Management Instrumentation)
 *
 */

using System;
using System.IO;
using System.Linq;
using System.Management;

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
