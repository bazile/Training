using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BelhardTraining.LessonIO
{
	/// <summary>
	/// Сортировка строк в логическом порядке. Например строки
	///		1.txt
	///		10.txt
	///		2.txt
	/// будут отсортированы в
	///		1.txt
	///		2.txt
	///		10.txt
	/// </summary>
	public class LogicalStringComparer : IComparer<string>
	{
		[DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
		static extern int StrCmpLogicalW(string x, string y);

		public int Compare(string x, string y)
		{
			return StrCmpLogicalW(x, y);
		}
	}
}
