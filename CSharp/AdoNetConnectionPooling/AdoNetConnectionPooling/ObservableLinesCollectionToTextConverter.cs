using System;
using System.Globalization;
using System.Windows.Data;

namespace BelhardTraining.ConnectionPoolingDemo
{
	public class ObservableLinesCollectionToTextConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			ObservableLinesCollection linesCollection = values[0] as ObservableLinesCollection;
			return linesCollection != null && linesCollection.Count > 0 ? linesCollection.Text : string.Empty;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}