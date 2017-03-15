using System.Windows.Forms;

namespace TrainingCenter.Windows.Forms
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
