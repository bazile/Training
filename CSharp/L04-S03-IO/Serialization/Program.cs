/*
 * Демонстраниция различных способов сериализации объекта в .NET
 * 
 * Сериализация – механизм сохранения значения переменной типа в 
 * поток с возможностью последующего востановления точной 
 * копии (десериализация).
 * 
 * .NET поддерживает следующие виды сериализации
 *		Бинарная (привязана к .NET)
 *		Текстовая в формате XML
 *		Текстовая в формате JSON (JavaScript Object Notation)
 *		
 * Также существуют сторонние реализации сериализации для .NET
 * Например, Protocol Buffers от Google
 * https://developers.google.com/protocol-buffers/
 * 
 */
using System;

namespace Serialization
{
	partial class Program
	{
		static void Main()
		{
			ConsoleMenu menu = new ConsoleMenu();
			menu.AddItem("Бинарная сериализация", BinarySerializationDemo);
			menu.AddItem("XML сериализация"     , XmlSerializationDemo);
			menu.AddItem("JSON сериализация"    , JsonSerializationDemo);
			menu.AddItem("Выход"                , null);

			do
			{
				menu.Show();
			} while (!menu.ExitSelected);
		}

		private static void Header(string text)
		{
			ConsoleColor oldColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(text);
			Console.WriteLine(new string('=', text.Length));
			Console.ForegroundColor = oldColor;
			Console.WriteLine();
		}

		private static void Comment(string text)
		{
			ConsoleColor oldColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(text);
			Console.ForegroundColor = oldColor;
		}

		private static void Pause()
		{
			Console.WriteLine();
			Console.WriteLine("Нажмите любую клавишу для продолжения ...");
			Console.ReadKey(true);
		}
	}
}
