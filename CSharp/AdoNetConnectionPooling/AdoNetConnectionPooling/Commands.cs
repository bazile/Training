﻿using System.Windows.Input;

namespace BelhardTraining.ConnectionPoolingDemo
{
	public static class Commands
	{
		public static readonly RoutedUICommand Start = new RoutedUICommand("Start", "Start", typeof(MainWindow));
	}
}
