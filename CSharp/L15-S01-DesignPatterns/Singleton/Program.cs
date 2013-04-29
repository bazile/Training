using System;

namespace Singleton
{
	class Program
	{
		static void Main()
		{
			// Экземпляры System.Type являются синглтонами
			Type t1 = typeof(int);
			Type t2 = Type.GetType("System.Int32");
			Console.WriteLine(Object.ReferenceEquals(t1, t2));

			#region Cтроки: объединение, интернирование, пустые строки

			//string xyz1 = "xyz";
			//string xyz2 = "x" + "y" + "z";
			//string xyz3 = new string(new[] {'x', 'y', 'z'});
			//Console.WriteLine("xyz1 и xyz2 указывают на один адрес? - {0}", ReferenceEquals(xyz1, xyz2));
			//Console.WriteLine("xyz1 и xyz3 указывают на один адрес? - {0}", ReferenceEquals(xyz1, xyz3));
			//xyz3 = String.Intern(xyz3);
			//// Теперь xyz1, xyz2 и xyz3 указывают на одну и ту же строку
			//Console.WriteLine("xyz1 и xyz3 указывают на один адрес? - {0}", ReferenceEquals(xyz1, xyz3));

			//Console.WriteLine();
			//string empty1 = "";
			//string empty2 = String.Empty;
			//Console.WriteLine("empty1 и empty2 указывают на один адрес? - {0}", ReferenceEquals(empty1, empty2));

			#endregion
		}
	}
}
