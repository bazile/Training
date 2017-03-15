using System;
using System.Threading;
using System.Windows.Forms;

/*
 * Демонстрация взаимоблокировки при неправильном использовании Control.Invoke
 */

#region Как исправить эту ошибку?

// Вызов _unlocked.Set() должен стоять перед Invoke(...)
// Таки образом UI поток закончит выполнение обработчика события Click
//	и сможет обрабатывать сообщения от операцинной системы

#endregion

namespace TrainingCenter.ControlInvokeDeadlock
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		
		// Создаем событие в несигнализированном состоянии
		ManualResetEvent _unlocked = new ManualResetEvent(false);

		private void bigButton_Click(object sender, EventArgs e)
		{
			Thread deadlockThread = new Thread(Deadlock);
			deadlockThread.Name = "Мой поток";
			deadlockThread.Start();

			statusLabel.Text = "Взаимоблокировка :(";
			
			// Ждем перехода события в сигнальное состояние
			// Это никогда не произойдет т.к. событие переводится в сигнальное состояние
			//	после вызова Control.Invoke который ждет когда UI поток освободится который 
			//	ждет сигнала от второго потока который ждет UI поток который ....
			// То из-за неправильного взаимодействия потоков мы получили взаимоблокировку
			_unlocked.WaitOne();
		}

		void Deadlock()
		{
			// Пытаемся обновить UI. Метод Invoke блокирует исполнение текущего потока 
			//	пока UI поток не выполнит запрошенное действие
			//	Однако это никогда не прозойдет т.к. UI поток заблокирован
			//	вызовом _unlocked.WaitOne() и не может обрабатывать сообщения из очереди
			Invoke((Action)delegate() {
				statusLabel.Text = "Избежали взаимоблокировки!";
			});
			
			// Переводим событие в сигнальное состояние
			// Следующая строка никогда не выполнится
			_unlocked.Set();
		}
	}
}
