using System;
using System.Windows.Controls.Primitives;

namespace BelhardTraining.ConnectionPoolingDemo
{
	static class ControlExtensions
	{
		public static void AppendLine(this TextBoxBase textBox, string line)
		{
			textBox.AppendText(line);
			textBox.AppendText(Environment.NewLine);
		}
	}
}
