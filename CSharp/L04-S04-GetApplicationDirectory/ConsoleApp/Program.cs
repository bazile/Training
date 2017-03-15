using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainingCenter.LessonIO
{
	class Program
	{
		static void Main()
		{
			List<Tuple<string, string>> pathVariants = ApplicationDirectory.GetAll();
			int maxRemLen = pathVariants.Max(v => v.Item1.Length);
			foreach (Tuple<string, string> pathVariant in pathVariants)
			{
				Console.WriteLine("{0}: {1}", pathVariant.Item1.PadRight(maxRemLen), pathVariant.Item2);
			}

			Console.ReadLine();
		}
	}
}
