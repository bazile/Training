using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadsDemo.Queue
{
	public class ActionQueue<T> : IDisposable where T : class
	{
		private readonly Queue<T> _queue = new Queue<T>();  //Очередь объектов
		private readonly Thread _thread;                    //Поток - потребитель
		private readonly EventWaitHandle _waitHandle = new AutoResetEvent(false);   //Объект для синхронизации
		private readonly Action<T> _action;                 //Делегат на метод - обработчик

		public ActionQueue(Action<T> action)
		{
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			_action = action;                   //Устанавливаем делегат на метод-обработчик
			_thread = new Thread(MainLoop);     //Запускаем поток
			_thread.IsBackground = true;
			_thread.Start();
		}

		public void EnqueueElement(T element)   //Метод добавления объекта в очередь
		{
			lock (_queue)                       //Блокируем очередь
			{
				_queue.Enqueue(element);        //Помещаем объект в очередь
			}
			_waitHandle.Set();                  //Будим возможно спящий поток-потребитель, Отправляем сигнал.
		}

		public void Stop()                      //Метод остановки обработчика
		{
			EnqueueElement(null);               //Добавляем null указатель, чтобы завершить поток-потребитель
			_thread.Join();                     //Ждем завершения потока
			_waitHandle.Reset();                //Сбрасываем объект синхронизации.
		}

		public void Dispose()
		{
			_waitHandle.Close();                //Закрываем объект синхронизации
		}

		private void MainLoop()                 //Метод, выполняющий поток-потребитель
		{
			while (true)
			{
				T element = null;
				lock (_queue)
				{
					if (_queue.Count > 0)
					{
						element = _queue.Dequeue(); //Извлекаем следующий элемент из очереди
						if (element == null)        //Если вместо него - указатель на null...
						{
							return;                 //...завершаем поток-потребитель
						}
					}
				}
				if (element != null)                //Если элемент не null
				{
					_action(element);               //Вызываем метод обработчик через делегата
				}
				else
				{
					_waitHandle.WaitOne();          //Иначе - ждем пополнения в очереди.
				}
			}
		}
	}
}
