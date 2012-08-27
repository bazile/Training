using System;
using System.Threading;

namespace ThreadsDemo_01
{
	class Program
	{
		static void Main(string[] args)
		{
			Thread backThread = new Thread(new ThreadStart(PrintMessage));
			Thread paramThread = new Thread(new ParameterizedThreadStart(PrintMessage));
			backThread.Start();
			paramThread.Start("I'm parameterized thread!");

			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("I'm main thread!");
			}

			// Ожидаем завершения потоков
			backThread.Join();
			paramThread.Join();
		}

		public static void PrintMessage()
		{
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("I'm background thread!");
			}
		}

		public static void PrintMessage(object text)
		{
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine(text);
			}
		}
	}
}
