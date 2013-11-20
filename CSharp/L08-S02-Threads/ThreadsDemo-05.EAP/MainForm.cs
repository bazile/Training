using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BelhardTraining.Downloader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            List<TestFileInfo> testFiles = new List<TestFileInfo>
                {
                    new TestFileInfo{ FileName="100kb.txt", MD5Hash = "869c2d2bacc13741416c6303a3a92282" },
                    new TestFileInfo{ FileName="200kb.txt", MD5Hash = "311ab5235761d035b3aab403aff9e38a" },
                    new TestFileInfo{ FileName="500kb.txt", MD5Hash = "4a03765e49cbd8d932ae9af806728042" },
                    new TestFileInfo{ FileName="1mb.txt"  , MD5Hash = "c012b96cbeabc33af59f4209e3bd2882" },
                    new TestFileInfo{ FileName="2mb.txt"  , MD5Hash = "7db5fc1f8540e76e4634b8cbc843e40e" },
                    new TestFileInfo{ FileName="5mb.txt"  , MD5Hash = "d7745661a090d08d56f7064284d75d42" },
                    new TestFileInfo{ FileName="10mb.txt" , MD5Hash = "c92d634e49d5e8ee6de555ff0d66651a" },
                    new TestFileInfo{ FileName="20mb.txt" , MD5Hash = "8f4e33f3dc3e414ff94e5fb6905cba8c" },
                    new TestFileInfo{ FileName="50mb.txt" , MD5Hash = "244801fbc88fd9957cd166f765abe26a" },
                    new TestFileInfo{ FileName="100mb.txt", MD5Hash = "4c77a0629753f73291d3eda0f0ae57f7" },
                    new TestFileInfo{ FileName="200mb.txt", MD5Hash = "eda9a9889837ac4bc81d6387d92c1bec" },
                    //new TestFileInfo{ FileName="500mb.txt", MD5Hash = "7583b57452ccb83f9d313ab76e3629b8" },
                    //new TestFileInfo{ FileName="1gb.txt"  , MD5Hash = "b5c667a723a10a3485a33263c4c2b978" },
                    //new TestFileInfo{ FileName="2gb.txt"  , MD5Hash = "b8f1f1faa6dda5426abffb3a7811c1fb" },
                    //new TestFileInfo{ FileName="5gb.txt"  , MD5Hash = "20096e4b3b80a3896dec3d7fdf5d1bfc" },
                };
            comboBox1.DataSource = testFiles;
            //comboBox1.SelectedValue = "1mb.txt";
        }

        // TODO: Закончить пример

        private void OnButtonDownloadClick(object sender, System.EventArgs e)
        {
            TestFileInfo selectedFile = (TestFileInfo)comboBox1.SelectedValue;

            WebClient webClient = new WebClient();
            //webClient.DownloadProgressChanged += OnDownloadProgressChanged;
            webClient.DownloadDataCompleted += OnDownloadDataCompleted;
            webClient.DownloadDataAsync(new Uri("http://ftp.byfly.by/test/" + selectedFile.FileName), selectedFile);
        }

        private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            int percent = (int)(100 * ((double)e.BytesReceived / e.TotalBytesToReceive));
        }

        private void OnDownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            TestFileInfo requestedFile = (TestFileInfo)e.UserState;
            byte[] data = e.Result;

            // Вычисляем MD5 хеш скачанных данных чтобы убедиться что файл скачался без ошибок
            MD5CryptoServiceProvider md5svc = new MD5CryptoServiceProvider();
            byte[] hashBytes = md5svc.ComputeHash(data);
            string hash = ByteArrayToString(hashBytes);

            if (requestedFile.MD5Hash.Equals(hash, StringComparison.OrdinalIgnoreCase))
                MessageBox.Show("Успех!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Ошибка!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static string ByteArrayToString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length*2);
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.AppendFormat("{0:X2}", bytes[i]);
            }
            return sb.ToString();
        }

        private class TestFileInfo
        {
            public string FileName;
            public string MD5Hash;

            public override string ToString()
            {
                return FileName;
            }
        }
    }
}
