using System;
using System.Threading;

namespace ThreadsDemo.ConsoleMessages
{
	class Program
	{
		static void Main()
		{
			var backThread = new Thread(new ThreadStart(PrintMessage));
			//backThread.IsBackground = true;

			//var paramThread = new Thread(new ParameterizedThreadStart(PrintMessage));
			//paramThread.IsBackground = true;

			var paramThread = new Thread(new ParameterizedThreadStart(PrintComplexMessage));
			//paramThread.IsBackground = true;

			backThread.Start();
			//paramThread.Start("I'm parameterized thread!");
			paramThread.Start(new PrintMessageData { Message = "I'm super-parameterized thread!", When = DateTime.Now});

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

		public static void PrintComplexMessage(object obj)
		{
			var data = (PrintMessageData)obj;
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("{0:g} - {1}", data.When, data.Message);
			}
		}

		private class PrintMessageData
		{
			public string Message;
			public DateTime When;
		}
	}
}
