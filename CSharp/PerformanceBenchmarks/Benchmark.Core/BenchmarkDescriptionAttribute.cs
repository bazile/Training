using System;

namespace BelhardTraining.Benchmark.Core
{
	[AttributeUsage(AttributeTargets.Assembly)]
	public sealed class BenchmarkDescriptionAttribute : Attribute
	{
		private readonly string _benchmarkDescription;

		public BenchmarkDescriptionAttribute(string benchmarkDescription)
		{
			_benchmarkDescription = benchmarkDescription;
		}

		public string BenchmarkDescription
		{
			get { return _benchmarkDescription; }
		}
	}
}
