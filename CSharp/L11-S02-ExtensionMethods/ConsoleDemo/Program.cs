﻿using System;
using TrainingCenter.Extensions;

namespace TrainingCenter.ExtensionMethodsDemo
{
	class Program
	{
		static void Main()
		{
			string name = "aникей";
			// Вызываем свой extension-метод ToTitleCase()
			Console.WriteLine(name.ToTitleCase());

			Guid guid = Guid.NewGuid();
			// Вызываем свой extension-метод ToHexString()
			Console.WriteLine("Guid: " + guid.ToByteArray().ToHexString('-'));
		}
	}
}
