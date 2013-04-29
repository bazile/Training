using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DeepCopy
{
	class Program
	{
		static void Main()
		{
			var names = new List<string>();
			names.AddRange(new[]{"Аникей", "Болеслава", "Всеслав", "Добрыня", "Забава", "Владимир"});
			var namesCopy = names.DeepClone();

			Console.WriteLine("Адреса равны? {0}", ReferenceEquals(names, namesCopy));
			Console.WriteLine("Кол-во элементов одинаковое? {0}", names.Count == namesCopy.Count);
			Console.WriteLine();
			Console.WriteLine("Сравниваем элементы:");
			for (int i = 0; i < names.Count; i++)
			{
				Console.WriteLine("Адреса равны? {0}, Значения равны? {1}", ReferenceEquals(names[i], namesCopy[i]), names[i] == namesCopy[i]);
			}
		}
	}

	public static class ExtensionMethods
	{
		/// <summary>
		/// Создает полную копию класса с помощью бинарной сериализации
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="a"></param>
		/// <returns></returns>
		/// <remarks>
		/// Тип <typeparamref name="T"/> должен быть помечен атрибутом Serializable
		/// </remarks>
		public static T DeepClone<T>(this T a)
		{
			using (var stream = new MemoryStream())
			{
				var formatter = new BinaryFormatter();
				formatter.Serialize(stream, a);
				stream.Position = 0;
				return (T)formatter.Deserialize(stream);
			}
		}		
	}
}
