using System.Reflection;
using BenchmarkDotNet;

namespace BelhardTraining.Benchmark.Core
{
	public class BelhardBenchmarkCompetition : BenchmarkCompetition
	{
		public override string Name
		{
			get
			{
				var asm = Assembly.GetExecutingAssembly();
				object[] attributes = asm.GetCustomAttributes(typeof(BenchmarkDescriptionAttribute), false);
				if (attributes.Length == 0) return base.Name;

				return ((BenchmarkDescriptionAttribute)attributes[0]).BenchmarkDescription;
			}
		}
	}
}
