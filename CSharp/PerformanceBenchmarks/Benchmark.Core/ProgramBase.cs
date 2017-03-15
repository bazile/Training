using System;

namespace TrainingCenter.Benchmark.Core
{
	public abstract class ProgramBase
	{
		protected abstract Tuple<string, string, Action>[] GetBenhmarkList();

		public BelhardBenchmarkCompetition GetBenchmarkCompetition(string benchmarkId)
		{
			var benchmarks = GetBenhmarkList();

			var competition = new BelhardBenchmarkCompetition();
			foreach (var tuple in benchmarks)
			{
				string id = tuple.Item1;
				Action benchmark = tuple.Item3;
				string comment = tuple.Item2;

				if (benchmarkId == null)
				{
					competition.AddTask(comment, benchmark);
				}
				else if (string.Equals(benchmarkId, id, StringComparison.OrdinalIgnoreCase))
				{
					competition.AddTask(comment, benchmark);
					break;
				}
			}
			return competition;
		}
	}
}
