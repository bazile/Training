// Если проект открыт в Visual Studio 2012, то переключите проект на .NET 4.5
//	и уберите комментарий со следующей строки
//#define DOTNET_45

using System.ComponentModel;

namespace wpf_ObservableObject
{
	internal class ObservableObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

#if DOTNET_45
		protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]string propertyName = null)
#else
		protected virtual void OnPropertyChanged(string propertyName)
#endif
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}

	internal class Employee : ObservableObject
	{
		private string _name;
		private string _surname;

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
#if DOTNET_45
				OnPropertyChanged();
#else
				OnPropertyChanged("Name");
#endif
			}
		}

		public string Surname
		{
			get { return _surname; }
			set
			{
				_surname= value;
#if DOTNET_45
				OnPropertyChanged();
#else
				OnPropertyChanged("Surname");
#endif
			}
		}
	}
}
