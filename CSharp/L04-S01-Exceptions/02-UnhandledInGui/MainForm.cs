using System;
using System.Windows.Forms;

namespace TrainingCenter.ExceptionsDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            int n = int.Parse(tbValue.Text);
            lblResult.Visible = true;
            lblResult.Text = string.Format("Введено число: {0}", n);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "В случае возникновения необработанного исключения GUI приложение завершит свою работу. "
                + "В зависимости от версии Windows и её настроек вы увидите разные сообщения об ошибке. "
                + "\n\nПопробуйте ввести число, пустую строку, строку которую нельзя перевести в int или очень большое число."
                , "Справка"
            );

        }
    }
}
