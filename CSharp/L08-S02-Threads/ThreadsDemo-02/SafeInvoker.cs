using System;
using System.Windows.Forms;

namespace ThreadsDemo.WinForms.Invoke
{
	internal static class SafeInvoker
	{
		/// <summary>
		/// Функция упрощающая использование Invoke() для Windows Forms приложений
		/// </summary>
		/// <param name="ctrl">Элемент управления для которого необходимо вызвать Invoke()</param>
		/// <param name="cmd"></param>
		/// <example>myCtrl.SafeInvoke(() => myCtrl.Enabled = false);</example>
		public static void SafeInvoke(this Control ctrl, Action cmd)
		{
			if (ctrl.InvokeRequired)
				ctrl.BeginInvoke(cmd);
			else
				cmd();
		}

		/// <summary>
		/// Замена для фукнций вида OnEvent
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="evnt"></param>
		/// <example>this.RaiseEvent(OnFormLoad);</example>
		public static void RaiseEvent(this object sender, EventHandler evnt)
		{
			EventHandler temp = evnt;
			if (temp != null)
			{
				temp(sender, EventArgs.Empty);
			}
		}
	}
}
