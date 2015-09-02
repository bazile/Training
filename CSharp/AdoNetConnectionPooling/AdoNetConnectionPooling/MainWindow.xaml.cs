using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

// Идея: http://www.pythian.com/blog/sql-server-understanding-and-controlling-connection/

namespace BelhardTraining.ConnectionPoolingDemo
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			_viewModel = new MainWindowViewModel();
			_presenter = new MainWindowPresenter(_viewModel);

			InitializeComponent();

			using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			using (var key = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL"))
			{
				string[] names = key.GetValueNames();
				if (names.Length > 0)
				{
					if ("MSSQLSERVER".Equals(names[0], StringComparison.OrdinalIgnoreCase))
					{
						tbServer.Text = "localhost";
					}
					else
					{
						tbServer.Text = @"localhost\" + names[0];
					}
				}
			}

			Title = App.GetInstanceName();

			myGrid.DataContext = _viewModel;
		}

		MainWindowPresenter _presenter;
		MainWindowViewModel _viewModel;

		private void CanExecuteStart(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = !string.IsNullOrWhiteSpace(tbServer.Text) && !_viewModel.PoolTestRunning;
		}

		private void ExecuteStart(object sender, RoutedEventArgs e)
		{
			if (!_viewModel.DoNotShowWarning)
			{
				using (TaskDialog dlg = new TaskDialog())
				{
					dlg.Caption = "Подтвердите операцию";
					dlg.Text = "Во время своей работы приложение создаст временные базы данных на указанном вами сервере. Они будут удалены сразу после окончания тестирования.\r\n\r\nНе используйте данное приложение с рабочим SQL Server!";
					dlg.Cancelable = true;
					var okLink = new TaskDialogCommandLink("ok", "Согласен. Продолжаем!");
					okLink.Click += (sender2, e2) => ((TaskDialog)((TaskDialogCommandLink)sender2).HostingDialog).Close(TaskDialogResult.Ok);
					var cancelLink = new TaskDialogCommandLink("cancel", "Я передумал") {Default = true};
					cancelLink.Click += (sender2, e2) => ((TaskDialog)((TaskDialogCommandLink)sender2).HostingDialog).Close(TaskDialogResult.Cancel);
					dlg.Controls.Add(okLink);
					dlg.Controls.Add(cancelLink);
					dlg.FooterCheckBoxText = "Больше не спрашивать";

					var result = dlg.Show();
					_viewModel.DoNotShowWarning = dlg.FooterCheckBoxChecked.Value;
					if (result != TaskDialogResult.Ok) return;
				}
			}

			_viewModel.PoolTestRunning = true;
			_viewModel.Server = tbServer.Text.Trim();
			_viewModel.UseSqlAuthentication = cbUseSqlAuth.IsChecked.Value;
			_viewModel.UserName = tbUserName.Text.Trim();
			_viewModel.Password = tbPassword.Password;
			_viewModel.LogLines.Clear();

			Thread t = new Thread(_presenter.RunPoolTest);
			t.Start();
		}

	}
}
