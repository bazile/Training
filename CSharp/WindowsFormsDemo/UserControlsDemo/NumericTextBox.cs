using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TrainingCenter.Windows.Forms.Controls
{
    public class NumericTextBox : TextBox
    {
        public NumericTextBox()
        {
            HandleCreated += OnHandleCreated;
        }

        public int Value
        {
            get { return Text.Length == 0 ? 0 : int.Parse(Text); }
            set { Text = value.ToString(); }
        }

        private void OnHandleCreated(object sender, EventArgs args)
        {
            const int ES_NUMBER = 0x2000;
            const int GWL_STYLE = -16;

            int style = GetWindowLong(Handle, GWL_STYLE);
            SetWindowLong(Handle, GWL_STYLE, style | ES_NUMBER);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_PASTE = 0x0302;
            if (m.Msg == WM_PASTE)
            {
                string text = Clipboard.GetText();
                if (string.IsNullOrEmpty(text)) return;

                if ((text.IndexOf('+') >= 0) && (SelectionStart != 0)) return;

                int i;
                if (!int.TryParse(text, out i)) return;

                if (i < 0 && SelectionStart != 0) return;
            }
            base.WndProc(ref m);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                HandleCreated -= OnHandleCreated;
            }

            base.Dispose(disposing);
        }

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    }
}
