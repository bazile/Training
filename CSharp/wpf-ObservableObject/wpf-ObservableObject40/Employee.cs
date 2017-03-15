namespace TrainingCenter.WpfDemo
{
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
				OnPropertyChanged();
			}
		}

		public string Surname
		{
			get { return _surname; }
			set
			{
				_surname = value;
				OnPropertyChanged();
			}
		}
	}
}
