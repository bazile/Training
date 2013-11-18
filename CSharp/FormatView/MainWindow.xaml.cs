using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace FormatView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ReadOnlyCollection<string> _numericFormats;

        public MainWindow()
        {
            InitializeComponent();

            var numericFormats = new List<string> {"c", "d", "e", "f", "g", "n", "p", "x"};
            _numericFormats = numericFormats.AsReadOnly();

            var x = GetFormatResuls(-10);
        }

        private ReadOnlyCollection<FormatResult<int>> GetFormatResuls(int num)
        {
            var formatResults = new List<FormatResult<int>>();
            foreach (string format in _numericFormats)
            {
                formatResults.Add(new FormatResult<int>(num, format));
            }
            return formatResults.AsReadOnly();
        }

        private void textBox1_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            listView1.BeginInit();
            listView1.Items.Clear();
            listView1.EndInit();
        }

        public List<FormatResult<DateTime>> results;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //string[] dateFormats = DateTime.Now.ToString()

            DateTime d = DateTime.Now;
            List<FormatStringInfo> dateFormats = FormatStrings.GetFormatString<DateTime>();
            List<FormatResult<DateTime>> tempResults = new List<FormatResult<DateTime>>();
            foreach (var fsi in dateFormats)
            {
                foreach (string format in fsi.Formats)
                {
                    var result = new FormatResult<DateTime>(d, format);
                    result.Comment = fsi.Name;
                    var lvi = new ListViewItem();
                    lvi.Content = result;
                    listView1.Items.Add(lvi);
                    //tempResults.Add(result);
                }
            }

            //listView1.DataContext = results;
            //results = tempResults;
        }
    }
}
