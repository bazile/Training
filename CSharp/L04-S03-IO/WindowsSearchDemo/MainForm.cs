using System;
using System.IO;
using System.Windows.Forms;
using SearchAPILib;

namespace TrainingCenter.LessonIO.WindowsSearchDemo
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			cbSearchPath.Items.Add(new PredefinedFolder
			{
				Name = "Меню «Пуск»",
				Path = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu)
			});
			int defaultPathIdx = cbSearchPath.Items.Add(new PredefinedFolder
			{
				Name = "Мои документы",
				Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
			});
			cbSearchPath.Items.Add(new PredefinedFolder
			{
				Name = "Рабочий стол",
				Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
			});
			cbSearchPath.SelectedIndex = defaultPathIdx;
		}

		class PredefinedFolder
		{
			public string Name;
			public string Path;

			public override string ToString()
			{
				return Name;
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			//const string connectionString = "Provider=Search.CollatorDSO; Extended Properties=\"Application=Windows\"";
			//using (OleDbConnection connection = new OleDbConnection(connectionString))
			//{
			//    // Список поддерживаемых свойств (обширный!) доступен на MSDN
			//    // https://msdn.microsoft.com/en-us/library/ff521735%28v=vs.85%29.aspx
			//    string query = @"SELECT System.ItemName, System.ItemFolderPathDisplayNarrow FROM SystemIndex " +
			//                   @"WHERE scope ='file\u003a" + GetSearchPath() + "'"; //" AND FREETEXT('XML')";
			//    OleDbCommand command = new OleDbCommand(query, connection);
			//    connection.Open();

			//    //List<string> result = new List<string>();

			//    OleDbDataReader reader = command.ExecuteReader();
			//    while (reader.Read())
			//    {
			//        //result.Add(reader.GetString(reader.GetOrdinal("System.ItemName")));
			//        listBox1.Items.Add(reader.GetString(reader.GetOrdinal("System.ItemName")));
			//    }
			//    //result.Dump();
			//}
			CSearchManager manager = new CSearchManagerClass();
			ISearchCatalogManager catalogManager = manager.GetCatalog("SystemIndex");
			//catalogManager.
			//ISearchQueryHelper queryHelper = catalogManager.GetQueryHelper();
			//queryHelper.

			//string sqlQuery = queryHelper.GenerateSQLFromUserQuery(aqsQuery);  
		}

		private void cbSearchPath_SelectedValueChanged(object sender, EventArgs e)
		{
			ValidatePath();
		}

		private void cbSearchPath_TextChanged(object sender, EventArgs e)
		{
			ValidatePath();
		}

		void ValidatePath()
		{
			string searchPath = GetSearchPath();
			btnSearch.Enabled = !string.IsNullOrEmpty(searchPath) && Directory.Exists(searchPath);
		}

		string GetSearchPath()
		{
			return cbSearchPath.SelectedItem == null
				? cbSearchPath.Text
				: ((PredefinedFolder)cbSearchPath.SelectedItem).Path;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				string searchPath = GetSearchPath();
				if (Directory.Exists(searchPath))
				{
					fbd.SelectedPath = searchPath;
				}
				if (fbd.ShowDialog() == DialogResult.OK)
				{
					cbSearchPath.Text = fbd.SelectedPath;
				}
			}
		}
	}
}
