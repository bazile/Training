using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BelhardTraining.EncodingViewer
{
    public partial class MainForm : Form
    {
        private readonly EncodingInfo _defaultEncodingInfo;
        private readonly EncodingInfo[] _allEncodingsInfo;
        private readonly EncodingInfo[] _preferableEncodingsInfo;

        public MainForm()
        {
            InitializeComponent();

            _allEncodingsInfo = Encoding.GetEncodings().OrderBy(ei => ei.DisplayName).ToArray();

            var preferredEncodingNames = new[] {"windows-1251", "koi8-r", "us-ascii", "utf-8", "utf-16", "utf-16BE", "utf-32", "utf-32BE"};
            _preferableEncodingsInfo = _allEncodingsInfo.Where(ei => preferredEncodingNames.Contains(ei.Name)).ToArray();

            const string defaultEncodingName = "utf-8";
            _defaultEncodingInfo = _preferableEncodingsInfo.Single(ei => defaultEncodingName.Equals(ei.Name));
        }

        #region Form Event Handlers

        private void OnLoad(object sender, EventArgs e)
        {
            InitEncodingsComboBox(_defaultEncodingInfo);
            DisplayEncodingCharacters(_defaultEncodingInfo);
        }

        private void OnCheckBoxShowAllEncodingsCheckedChanged(object sender, EventArgs e)
        {
            var selectedEncoding = (EncodingInfo)comboBoxEncoding.SelectedItem;
            InitEncodingsComboBox(selectedEncoding);
        }

        private void OnComboBoxEncodingSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEncoding = (EncodingInfo) comboBoxEncoding.SelectedItem;
            DisplayEncodingCharacters(selectedEncoding);
        }

        #endregion

        private void InitEncodingsComboBox(EncodingInfo selectedEncoding)
        {
            selectedEncoding = selectedEncoding ?? _defaultEncodingInfo;

            comboBoxEncoding.BeginUpdate();
            try
            {
                comboBoxEncoding.SelectedItem = null;

                EncodingInfo[] encodings = checkBoxShowAllEncodings.Checked
                                               ? _allEncodingsInfo
                                               : _preferableEncodingsInfo;
                comboBoxEncoding.DataSource = encodings;

                int idx = comboBoxEncoding.Items.IndexOf(selectedEncoding);
                if (idx == -1)
                {
                    idx = comboBoxEncoding.Items.IndexOf(_defaultEncodingInfo);
                }
                comboBoxEncoding.SelectedIndex = idx;
            }
            finally
            {
                comboBoxEncoding.EndUpdate();
            }
        }

        private void DisplayEncodingCharacters(EncodingInfo encodingInfo)
        {
            if (encodingInfo == null) return;

            listView1.BeginUpdate();

            try
            {
                var encoding = Encoding.GetEncoding(encodingInfo.Name, new EncoderReplacementFallback(""), new DecoderReplacementFallback(""));
                listView1.Items.Clear();

                var chars = new[]
                    {
                        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'
                        , 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
                        , 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
                        , 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ы', 'ъ', 'э', 'ю', 'я'
                        , 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ', 'Э', 'Ю', 'Я'
                    };
                for (int i=0; i<chars.Length; i++)
                {
                    string s = chars[i].ToString();
                    var item = new ListViewItem(s);
                    item.SubItems.Add(ByteArrayToString(encoding.GetBytes(s)));
                    listView1.Items.Add(item);
                }
            }
            finally
            {
                listView1.EndUpdate();
            }
        }

        private static string ByteArrayToString(byte[] buf)
        {
            var sb = new StringBuilder(buf.Length * 2);
            foreach (byte b in buf)
            {
                sb.AppendFormat("{0:x2} ", b);
            }
            if (sb.Length > 0) sb.Length -= 1;
            return sb.ToString();
        }
    }
}
