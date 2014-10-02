/*
 * Пример ObservableObject для .NET 4.5
 * 
 * В .NET 4.5 и выше есть тип System.Runtime.CompilerServices.CallerMemberNameAttribute
 * 
 */

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BelhardTraining.WpfDemo
{
	internal class ObservableObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		/// <remarks>
		/// Использование атрибута CallerMemberName избавляет от необходимости передавать вручную
		///		имя вызывающего метода
		/// </remarks>
		protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
