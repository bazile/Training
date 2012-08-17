using System;
using System.Security;

namespace StringDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			string str = "Текст";
			char ch = 'A';
			string strNull = null;
			string strEmpty1 = "";
			string strEmpty2 = String.Empty;

			string path1 = "c:\\Program Files\\Internet Explorer\\iexplore.exe";
			string path2 = @"c:\Program Files\Internet Explorer\iexplore.exe";

			//String.IsNullOrEmpty(s1);
			//String.IsNullOrWhiteSpace(s1);

			string sentence = "Кто давал совет 'играться, играться и еще раз играться'?";
			sentence = sentence.Replace("играться", "учиться");

			StringInternDemo();

			SecureStringDemo();
		}

		private static void StringInternDemo()
		{
			// Интернирование строк
			string s1 = new string('A', 10);
			string s2 = "AAAAAAAAAA";
			string s3 = "AAAAA" + "AAAAA";

			Console.WriteLine("Equals\n---------------");
			Console.WriteLine(s1.Equals(s2)); // true
			Console.WriteLine(s1.Equals(s3)); // true

			Console.WriteLine("\nReferenceEquals\n---------------");
			Console.WriteLine(ReferenceEquals(s1, s2)); // false
			Console.WriteLine(ReferenceEquals(s1, s3)); // false

			Console.WriteLine("\nReferenceEquals after String.Intern()\n---------------");
			s1 = String.Intern(s1);
			s2 = String.Intern(s2);
			Console.WriteLine(ReferenceEquals(s1, s2)); // true!
			Console.WriteLine(ReferenceEquals(s1, s3)); // true!
		}

		private static void SecureStringDemo()
		{
			// Пример работы с System.Security.SecureString
			// Задаем значение pa$sW0rD!
			SecureString password = new SecureString();
			password.AppendChar('p');
			password.AppendChar('a');
			password.AppendChar('$');
			password.AppendChar('s');
			password.AppendChar('W');
			password.AppendChar('0');
			password.AppendChar('r');
			password.AppendChar('D');
			password.AppendChar('!');
		}
	}
}
