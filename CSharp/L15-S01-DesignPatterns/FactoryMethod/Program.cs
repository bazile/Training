using System;
using System.Net;

namespace FactoryMethod
{
	class Program
	{
		static void Main()
		{
			var httpReq = WebRequest.Create("http://ya.ru");
			var ftpReq = WebRequest.Create("ftp://ya.ru");
			Console.WriteLine(httpReq.GetType());
			Console.WriteLine(ftpReq.GetType());
		}
	}

	class ComplexData
	{
		private ComplexData()
		{
		}

		public ComplexData Create()
		{
			var data = new ComplexData();
			// Сложная логика инициализация
			// ...
			return data;
		}
	}
}
