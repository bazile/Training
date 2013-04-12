using System;
using System.Threading;

namespace ThreadsDemo.ConsoleMessages
{
	class Program
	{
		static void Main()
		{
			var backThread = new Thread(new ThreadStart(PrintMessage));
			backThread.IsBackground = true;
			backThread.Start();

			var paramThread = new Thread(new ParameterizedThreadStart(PrintMessage));
			paramThread.IsBackground = true;
			paramThread.Start("I'm parameterized thread!");
			//var paramThread = new Thread(new ParameterizedThreadStart(PrintComplexMessage));
			//paramThread.IsBackground = true;
			//paramThread.Start(new PrintMessageData { Message = "I'm super-parameterized thread!", When = DateTime.Now});

			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("[{0}] I'm main thread!", i);
			}

			// Ожидаем завершения потоков
			backThread.Join();
			paramThread.Join();
		}

		private static void PrintMessage()
		{
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("[{0}] I'm background thread!", i);
			}
		}

		private static void PrintMessage(object text)
		{
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("[{0}] {1}", i, text);
			}
		}

		private static void PrintComplexMessage(object obj)
		{
			var data = (PrintMessageData)obj;
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("[{0}] {1:g} - {2}", i, data.When, data.Message);
			}
		}

		private class PrintMessageData
		{
			public string Message;
			public DateTime When;
		}
	}
}
