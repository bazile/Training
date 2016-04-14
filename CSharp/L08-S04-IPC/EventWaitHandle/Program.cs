using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace BelhardTraining.IPC.EventWaitHandleDemo
{
	class Program
	{
		const string EVENT_NAME = "BelhardTraining.IPC.EventWaitHandleDemo.{1AA07A5A-DBDB-4239-BB26-4B1ED3659FEB}";

		static void Main(string[] args)
		{
			//if (args.Length == 2 && args[0] == "-child")
			//{
			//    bool createdNew = false;
			//    EventWaitHandle h = new EventWaitHandle(false, EventResetMode.ManualReset, EVENT_NAME, out createdNew);
			//    //if (createdNew)
			//    //{
			//    //    h.Dispose();
			//    //}
				DummyInitialization();

			//}
			//else
			//{
			//    Console.WriteLine("1. Start child process");
			//}
		}

		private static void DummyInitialization()
		{
			Console.CursorVisible = false;

			const string message = "Initializing ... ";
			Console.Write(message);
			//Console.CursorLeft = message.Length;
			
			// Делаем вид что приложение выполняет инициализацию
			int randomDelay = (new Random()).Next(3, 13);
			char[] sequence = new[] {'|', '/', '-', '\\'};
			for (int i = 0, j=0; i < randomDelay*3; i++)
			{
				Console.Write(sequence[j++]);
				if (j >= sequence.Length) j = 0;
				Console.CursorLeft--;
												
				Thread.Sleep(300);
			}
			Console.WriteLine("Done.");

			Console.CursorVisible = true;
		}
	}
}
