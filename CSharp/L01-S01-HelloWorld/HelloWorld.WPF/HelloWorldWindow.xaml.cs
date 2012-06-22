using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace HelloWorld.WPF
{
	/// <summary>
	/// Interaction logic for HelloWorldWindow.xaml
	/// </summary>
	public partial class HelloWorldWindow : Window
	{
		public HelloWorldWindow()
		{
			InitializeComponent();
		}

		private void OnButtonHelloClick(object sender, RoutedEventArgs e)
		{
			Button helloButton = (Button)sender;
			helloButton.Foreground = Brushes.Red;

			DoubleAnimation da = new DoubleAnimation();
			da.From = helloButton.Width;
			da.To = da.From + 100;
			da.Duration = new Duration(TimeSpan.FromSeconds(1));
			da.AutoReverse = true;
			helloButton.BeginAnimation(Button.WidthProperty, da);
		}
	}
}
