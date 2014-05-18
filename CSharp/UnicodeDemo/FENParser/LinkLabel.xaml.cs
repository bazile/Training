using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Documents;

namespace FENParser
{
	public partial class LinkLabel : UserControl
	{
		// TODO: Finish LinkLabel control

		//public string Text { get; set; }
		//public string NavigateUri { get; set; }

		public LinkLabel()
		{
			InitializeComponent();

			link.ToolTip = Uri.UnescapeDataString(link.NavigateUri.AbsoluteUri);
		}

		private void OnLinkClick(object sender, System.Windows.RoutedEventArgs e)
		{
			string uriText = ((Hyperlink)sender).NavigateUri.AbsoluteUri;
			Process.Start(uriText);
		}
	}
}
