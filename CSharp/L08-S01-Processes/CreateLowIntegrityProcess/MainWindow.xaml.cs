/*
 * Демонстрация запуска процесса с низким integrity уровнем.
 * 
 * Процесса с низким integrity уровнем могут записывать только в 
 * специально разрешенные места как, например, папка %USER PROFILE%\AppData\LocalLow
 * или ключ HKEY_CURRENT_USER\Software\AppDataLow. При попытке выполнить запись
 * в расположение с более высоким integrity уровнем вы получите ошибку "доступ запрещен"
 * даже несмотря что текущая учетная запись пользователя имеет соответствующие права.
 * 
 * По умолчанию дочерние процессы наследуют integrity уровень родителя. Чтобы запустить
 * процесс с низким integrity уровнем необходимо создать соотвествующий токен с помощью
 * функции Windows API CreateProcessAsUser. Смотрите метод CreateLowIntegrityProcess в
 * классе ProccessIntegrityLevelHelper.
 * 
 * Большинство пользовательских процессов работает со средним integrity уровнем. Процесс
 * с низким integrity уровнем может понадобится когда необходимы повышенные меры безопасности
 * для защиты пользовательских данных. Например, дочерний процессы Internet Explorer работают
 * с низким integrity уровнем.
 */
using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows;

namespace TrainingCenter.LessonMultithreading
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				// Получаем и отображаем текущий integrity level
				IntegrityLevel il = ProccessIntegrityLevelHelper.GetCurrentProcessIntegrityLevel();
				switch (il)
				{
					case IntegrityLevel.Unknown  : lblIntegrityLevel.Content = "Неизвестный"; break;
					case IntegrityLevel.Untrusted: lblIntegrityLevel.Content = "Недоверенный"; break;
					case IntegrityLevel.Low      : lblIntegrityLevel.Content = "Низкий"; break;
					case IntegrityLevel.Medium   : lblIntegrityLevel.Content = "Средний"; break;
					case IntegrityLevel.High     : lblIntegrityLevel.Content = "Высокий"; break;
					case IntegrityLevel.System   : lblIntegrityLevel.Content = "Системный"; break;
				}
			}
			catch (Win32Exception)
			{
			    lblIntegrityLevel.Content = "N/A";
			}
		}

		private void OnRunButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// Пытаемся запустить свою копию с низким integrity уровнем
				ProccessIntegrityLevelHelper.CreateLowIntegrityProcess(GetExecutablePath());
			}
			catch (Win32Exception ex)
			{
				MessageBox.Show(ex.Message, "CreateLowIntegrityProcess Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void OnWriteButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string filePath = Path.Combine(KnownFolder.LocalAppData, "testfile.txt");

				File.WriteAllText(filePath, "CSCreateLowIntegrityProcess Test File");

				MessageBox.Show("Successfully write to the test file: " + filePath,
					"Test Result", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Writing to LocalAppData Failed",
					MessageBoxButton.OK, MessageBoxImage.Error);
			}

		}

		private void OnWriteLowButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string filePath = Path.Combine(KnownFolder.LocalAppDataLow, "testfile.txt");

				File.WriteAllText(filePath, "CSCreateLowIntegrityProcess Test File");

				MessageBox.Show("Successfully write to the test file: " + filePath,
					"Test Result", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Writing to LocalAppDataLow Failed",
					MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private static string GetExecutablePath()
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
