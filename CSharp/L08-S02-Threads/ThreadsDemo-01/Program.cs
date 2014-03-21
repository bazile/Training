using System;
using System.Threading;

namespace ThreadsDemo.ConsoleMessages
{
	class Program
	{
		static void Main()
		{
			var printMsgThread = new Thread(new ThreadStart(PrintMessage));
			//printMsgThread.IsBackground = true;
			printMsgThread.Name = "Поток #2";
			printMsgThread.Start();

			//var printThreadWithParam = new Thread(new ParameterizedThreadStart(PrintMessage));
			////printThreadWithParam.IsBackground = true;
			//printThreadWithParam.Name = "Поток #3";
			//printThreadWithParam.Start("Дополнительный поток с другим сообщением!");

			//var printThreadWithComplexParam = new Thread(new ParameterizedThreadStart(PrintComplexMessage));
			////printThreadWithComplexParam.IsBackground = true;
			////printThreadWithComplexParam.Start(new PrintMessageData { Message = "I'm super-parameterized thread!", When = new DateTime(2014, 3, 18) });
			//printThreadWithComplexParam.Name = "Поток #4";
			//printThreadWithComplexParam.Start("hggjdf");

			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("[{0:00}] Главный (UI) поток!", i);
			}

			// Ожидаем завершения потоков
			//printMsgThread.Join();
			//printThreadWithParam.Join();
		}

		private static void PrintMessage()
		{
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("[{0:00}] Дополнительный поток!", i);
			}
		}

		private static void PrintMessage(object text)
		{
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("[{0:00}] {1}", i, text);
			}
		}

		private static void PrintComplexMessage(object obj)
		{
			var data = (PrintMessageData)obj;
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("[{0:00}] {1:g} - {2}", i, data.When, data.Message);
			}
		}

		private class PrintMessageData
		{
			public string Message;
			public DateTime When;
		}
	}
}
