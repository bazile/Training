using System.Collections.ObjectModel;
using System.Text;

namespace TrainingCenter.ConnectionPoolingDemo
{
	class ObservableLinesCollection : ObservableCollection<string>
	{
		StringBuilder _sbLines = new StringBuilder();

		public string Text { get { return _sbLines.ToString(); }}

		public new void Add(string item)
		{
			_sbLines.Append(item);
			base.Add(item);
		}

		public void AddLine(string line)
		{
			Add(line + "\r\n");
		}

		public new void Clear()
		{
			_sbLines.Clear();
			base.Clear();
		}
	}
}