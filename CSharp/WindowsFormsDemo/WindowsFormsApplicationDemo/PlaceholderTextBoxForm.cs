using System;
using System.Windows.Forms;

namespace TrainingCenter.Windows.Forms
{
    public partial class PlaceholderTextBoxForm : DemoFormBase
    {
        public PlaceholderTextBoxForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            if (tbUserName.Text.Equals("admin", StringComparison.OrdinalIgnoreCase) && tbPassword.Text == "Pa$$word!")
            {
                MessageBox.Show("Правильный логин и пароль!", "Успех");
                Close();
            }
            else
            {
                MessageBox.Show("Неправильный логин и пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
