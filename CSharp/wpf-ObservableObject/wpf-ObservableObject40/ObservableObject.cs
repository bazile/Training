/*
 * Пример ObservableObject для .NET 4.0
 * 
 * В .NET 4.0 нет типа System.Runtime.CompilerServices.CallerMemberNameAttribute
 * Однако его можно использовать если подключить NuGet пакет Microsoft BCL Portability Pack (Microsoft.Bcl)
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
