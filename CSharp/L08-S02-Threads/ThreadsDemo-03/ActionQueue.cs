using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadsDemo.Queue
{
	public class ActionQueue<T> : IDisposable where T : class
	{
		private readonly Queue<T> queue = new Queue<T>();                   // Очередь объектов
		private Thread consumerThread;                                      // Поток - потребитель
		private AutoResetEvent newDataHandle = new AutoResetEvent(false);   // Объект для синхронизации
		private Action<T> consumerAction;                                   // Делегат на метод-обработчик

		public ActionQueue(Action<T> consumerAction)
		{
			if (consumerAction == null)
			{
				throw new ArgumentNullException("consumerAction");
			}
			this.consumerAction = consumerAction;       // Запоминаем делегат на метод-обработчик

			consumerThread = new Thread(DoConsume);     // Запускаем поток
			consumerThread.Name = "Поток класса ActionQueue";
			consumerThread.Start();
		}

		/// <summary>Добавление объекта в очередь</summary>
		public void EnqueueElement(T element)
		{
			lock (queue)                // Блокируем очередь
			{
				queue.Enqueue(element); // Помещаем объект в очередь
			}
			newDataHandle.Set();        // Будим возможно спящий поток-потребитель, Отправляем сигнал.
		}

		/// <summary>Остановка обработчика</summary>
		public void Stop()
		{
			Dispose();
		}

		public void Dispose()
		{
			if (consumerThread != null)
			{
				EnqueueElement(null);               // Добавляем null указатель, чтобы завершить поток-потребитель
				consumerThread.Join();              // Ждем завершения потока
				consumerThread = null;
			}
			if (newDataHandle != null)
			{
				newDataHandle.Close();              // Закрываем объект синхронизации
				newDataHandle = null;
			}
			consumerAction = null;
		}

		/// <summary>Поток-потребитель</summary>
		private void DoConsume()
		{
			while (true)
			{
				T element = null;
				lock (queue)
				{
					if (queue.Count > 0)
					{
						element = queue.Dequeue();  // Извлекаем следующий элемент из очереди
						if (element == null)        // Если вместо него - указатель на null...
						{
							return;                 // ...завершаем поток-потребитель
						}
					}
				}
				if (element != null)                // Если элемент не null
				{
					consumerAction(element);        // Вызываем метод обработчик через делегата
				}
				else
				{
					newDataHandle.WaitOne();         // Иначе - ждем пополнения в очереди.
				}
			}
		}
	}
}
