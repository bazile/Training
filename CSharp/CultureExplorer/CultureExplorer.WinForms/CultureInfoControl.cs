using System.Globalization;
using System.Windows.Forms;

namespace CultureExplorer.WinForms
{
	public partial class CultureInfoControl : UserControl
	{
		public CultureInfoControl()
		{
			InitializeComponent();
		}

		public void SetDataSource(CultureInfo cultureInfo)
		{
			cultureInfoViewModelBindingSource.DataSource = new CultureInfoViewModel(cultureInfo);
		}
	}
}
