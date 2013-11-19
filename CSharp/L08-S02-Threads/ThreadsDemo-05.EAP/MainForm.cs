using System.Windows.Forms;

namespace BelhardTraining.Downloader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // TODO: Закончить пример

        private void button1_Click(object sender, System.EventArgs e)
        {
            //ManualResetEvent waitHandle = new ManualResetEvent(false);
            //WebClient webClient = new WebClient();
            //webClient.DownloadProgressChanged += OnDownloadProgressChanged;
            //webClient.DownloadDataCompleted += OnDownloadDataCompleted;
            ////webClient.
            ////webClient.
            //webClient.DownloadStringAsync(new Uri("http://ftp.byfly.by/test/10mb.txt"), waitHandle);
            ////byte[] result = webClient.DownloadData("http://ftp.byfly.by/test/10mb.txt");
            ////byte[] result = webClient.DownloadData("http://ftp.byfly.by/pub/archlinux/pool/packages/aspell-nl-0.50.2-2-x86_64.pkg.tar.xz");
            ////e.Result = result;
            ////wc.DownloadProgressChanged += (o, args) => args.
            //waitHandle.WaitOne();
        }

        //private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        //{
        //    //WebClient webClient = (WebClient) sender;
        //    //webClient.T
        //    int percent = (int) (100*((double) e.BytesReceived/e.TotalBytesToReceive));
        //    backgroundWorker.ReportProgress(percent);
        //}

        //private void OnDownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        //{
        //    ManualResetEvent waitHandle = (ManualResetEvent) e.UserState;
        //    waitHandle.Set();
        //}
    }
}
