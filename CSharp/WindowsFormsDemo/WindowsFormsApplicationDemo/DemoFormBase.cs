using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BelhardTraining.Windows.Forms
{
    public class DemoFormBase : Form
    {
        public DemoFormBase()
        {
            FormClosed += HandleFormClosed;
        }

        private void HandleFormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.Close(this);
        }
    }
}
