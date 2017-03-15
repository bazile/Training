namespace TrainingCenter.ConnectionPoolingDemo
{
	class MainWindowViewModel
	{
		public ObservableLinesCollection LogLines { get; set; }
		public ObservableLinesCollection CountersLines { get; set; }

		public bool DoNotShowWarning { get; set; }
		public bool PoolTestRunning { get; set; }
		public string Password { get; set; }
		public string Server { get; set; }
		public string UserName { get; set; }
		public bool UseSqlAuthentication { get; set; }

		public MainWindowViewModel()
		{
			LogLines = new ObservableLinesCollection();
			CountersLines = new ObservableLinesCollection();
		}
	}
}
