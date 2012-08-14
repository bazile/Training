using System.Collections;
using System.Collections.Generic;

namespace MyVector
{
	/// <summary>
	/// Класс Vector дает возможность хранить произвольное количество целых чисел и считать их сумму
	/// </summary>
	public partial class IntVector : IEnumerable<int>
	{
		#region IEnumerator<int> implementation

		public IEnumerator<int> GetEnumerator()
		{
			for (int i = 0; i < _numbers.Length; i++)
			{
				yield return _numbers[i];
			}
		}

		#endregion

		#region IEnumerator implementation

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		
		#endregion
	}
}
