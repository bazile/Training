using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadsDemo.Queue
{
	public class ActionQueue<T> : IDisposable where T : class
	{
		private readonly Queue<T> queue = new Queue<T>();  // Очередь объектов
		private readonly Thread consumerThread;                    // Поток - потребитель
		private readonly AutoResetEvent newDataHandle = new AutoResetEvent(false);   // Объект для синхронизации
		private readonly Action<T> consumerAction;                 // Делегат на метод-обработчик

		public ActionQueue(Action<T> consumerAction)
		{
			if (consumerAction == null)
			{
				throw new ArgumentNullException("consumerAction");
			}
			this.consumerAction = consumerAction;                   // Запоминаем делегат на метод-обработчик

			consumerThread = new Thread(DoConsume);     //Запускаем поток
			consumerThread.Start();
		}

		public void EnqueueElement(T element)   //Метод добавления объекта в очередь
		{
			lock (queue)                       //Блокируем очередь
			{
				queue.Enqueue(element);        //Помещаем объект в очередь
			}
			newDataHandle.Set();                  //Будим возможно спящий поток-потребитель, Отправляем сигнал.
		}

		public void Stop()                      //Метод остановки обработчика
		{
			EnqueueElement(null);               //Добавляем null указатель, чтобы завершить поток-потребитель
			consumerThread.Join();                     //Ждем завершения потока
			newDataHandle.Reset();                //Сбрасываем объект синхронизации.
		}

		public void Dispose()
		{
			newDataHandle.Close();                //Закрываем объект синхронизации
		}

		private void DoConsume()                 //Метод, выполняющий поток-потребитель
		{
			while (true)
			{
				T element = null;
				lock (queue)
				{
					if (queue.Count > 0)
					{
						element = queue.Dequeue(); //Извлекаем следующий элемент из очереди
						if (element == null)        //Если вместо него - указатель на null...
						{
							return;                 //...завершаем поток-потребитель
						}
					}
				}
				if (element != null)                //Если элемент не null
				{
					consumerAction(element);               //Вызываем метод обработчик через делегата
				}
				else
				{
					newDataHandle.WaitOne();          //Иначе - ждем пополнения в очереди.
				}
			}
		}
	}
}
