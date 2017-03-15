using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrainingCenter.LessonIO
{
	public static partial class ApplicationDirectory
	{
		static partial void AddApplicationSpecificInfo(List<Tuple<string, string>> directoryInfo)
		{
			directoryInfo.Add(Tuple.Create("Application.StartupPath", Application.StartupPath));
		}
	}
}
