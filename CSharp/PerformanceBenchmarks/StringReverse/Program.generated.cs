using System;
using BelhardTraining.Benchmark.Core;

namespace StringReverse
{
	partial class Program
	{
		static BelhardBenchmarkCompetition GetBenchmarkCompetition(string benchmarkId)
		{
			var benchmarks = new[] {
				Tuple.Create<string, string, Action>("VeryBadReverse" , "Очень плохо №1", VeryBadReverseBenchmark),
				Tuple.Create<string, string, Action>("StillBadReverse", "Очень плохо №2", StillBadReverseBenchmark),
				Tuple.Create<string, string, Action>("LinqReverse"    , "Плохо (LINQ)"  , LinqReverseBenchmark),
				Tuple.Create<string, string, Action>("GoodReverse"    , "Хорошо"        , GoodReverseBenchmark),
				Tuple.Create<string, string, Action>("Reverse"        , "Отлично"       , ReverseBenchmark),
			};

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

		static void VeryBadReverseBenchmark()
		{
			for (int i=0; i<iterations; i++)
			{
				VeryBadReverse(TestString);
			}
		}
		static void StillBadReverseBenchmark()
		{
			for (int i=0; i<iterations; i++)
			{
				StillBadReverse(TestString);
			}
		}
		static void LinqReverseBenchmark()
		{
			for (int i=0; i<iterations; i++)
			{
				LinqReverse(TestString);
			}
		}
		static void GoodReverseBenchmark()
		{
			for (int i=0; i<iterations; i++)
			{
				GoodReverse(TestString);
			}
		}
		static void ReverseBenchmark()
		{
			for (int i=0; i<iterations; i++)
			{
				Reverse(TestString);
			}
		}
	}
}
