using System;
using System.Windows.Forms;

namespace RunNonElevated
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major < 6)
            {
                MessageBox.Show("Этому приложению требуется Windows Vista или более старшая версия!");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
