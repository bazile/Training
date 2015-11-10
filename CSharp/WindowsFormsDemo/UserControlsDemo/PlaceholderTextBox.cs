using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BelhardTraining.Windows.Forms.Controls
{
	public class PlaceholderTextBox : TextBox
	{
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			if (!string.IsNullOrWhiteSpace(_placeholderText))
			{
				SendMessage(Handle, EM_SETCUEBANNER, 0, _placeholderText);
			}
		}

		string _placeholderText;
		public string PlaceholderText
		{
			get { return _placeholderText; }
			set
			{
				_placeholderText = value;
				if (IsHandleCreated)
				{
					SendMessage(Handle, EM_SETCUEBANNER, 0, _placeholderText);
				}
			}
		}

		const int EM_SETCUEBANNER = 0x1501;

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		static extern Int32 SendMessage(
			IntPtr hWnd,
			int msg,
			int wParam,
			[MarshalAs(UnmanagedType.LPWStr)]string lParam);
	}
}
