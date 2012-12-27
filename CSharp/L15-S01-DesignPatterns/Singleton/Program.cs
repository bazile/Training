using System;
using System.Diagnostics;

namespace Singleton
{
	class Program
	{
		static void Main()
		{
			// Экземпляры System.Type являются синглтонами
			Type t1 = typeof(int);
			Type t2 = Type.GetType("System.Int32");
			Debug.Assert(Object.ReferenceEquals(t1, t2));
		}
	}
}
