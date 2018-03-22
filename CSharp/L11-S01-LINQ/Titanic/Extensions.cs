using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.LinqToObjectsDemo.Titanic
{
	static class Extensions
	{
		public static bool Is(this string s, string other)
		{
			return string.Equals(s, other, StringComparison.CurrentCultureIgnoreCase);
		}
	}
}
