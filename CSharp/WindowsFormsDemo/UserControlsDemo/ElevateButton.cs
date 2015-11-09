using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BelhardTraining.Windows.Forms.Controls
{
	public class ElevateButton : Button
	{
		public ElevateButton()
		{
			HandleCreated += OnHandleCreated;

			FlatStyle = FlatStyle.System;
		}

		private void OnHandleCreated(object sender, EventArgs e)
		{
			SendMessage(Handle, BCM_SETSHIELD, 0, 1);
		}

		[Browsable(false)]
		public new FlatStyle FlatStyle
		{
			get { return base.FlatStyle; }
			set { base.FlatStyle = value; }
		}

		[Browsable(false)]
		public new FlatButtonAppearance FlatAppearance
		{
			get { return base.FlatAppearance; }
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				HandleCreated -= OnHandleCreated;
			}

			base.Dispose(disposing);
		}
		
		// TODO: use IntPtr because int will crash app in x64?
		[DllImport("user32.dll")]
		private static extern int SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

		const int BCM_SETSHIELD = 0x160C;
	}
}
