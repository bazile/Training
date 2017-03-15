using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrainingCenter.Windows.Forms
{
    static class FormManager
    {
        static List<Form> _activeForms = new List<Form>();

        public static void Show<TForm>() where TForm : Form, new()
        {
            var form = _activeForms.OfType<TForm>().SingleOrDefault();
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                form = new TForm();
                _activeForms.Add(form);
                form.Show();
            }
        }

        internal static void Close(Form form)
        {
            _activeForms.Remove(form);
        }
    }
}
