using System;
using BelhardTraining.Benchmark.Core;

namespace AvoidBoxingToString
{
	class Program : ProgramBase
	{
		private const int Iterations = 3000000;

		static void Main(string[] args)
		{
			string benchmarkId = args.Length == 1 ? args[0] : null;
			var competition = (new Program()).GetBenchmarkCompetition(benchmarkId);
			competition.Run();
		}

		protected override Tuple<string, string, Action>[] GetBenhmarkList()
		{
			return new[] {
				Tuple.Create<string, string, Action>("ConcatObjects"      , "ConcatObjects"      , ConcatMessageWithBoxingBenchmark),
				Tuple.Create<string, string, Action>("ConcatStrings"      , "ConcatStrings"      , ConcatMessageAvoidingBoxingBenchmark),
				Tuple.Create<string, string, Action>("FormatWithBoxing"   , "FormatWithBoxing"   , FormatMessageWithBoxingBenchmark),
				Tuple.Create<string, string, Action>("FormatWithoutBoxing", "FormatWithoutBoxing", FormatMessageAvoidingBoxingBenchmark)
			};
		}

		private static void ConcatMessageWithBoxingBenchmark()
		{
			for (int i = 0; i < Iterations; i++)
			{
				ConcatMessageWithBoxing(1, 42);
			}
		}
		static string ConcatMessageWithBoxing(int id, int size)
		{
			// Из-за использования char компилятор сгенерирует вызов string.Concat(object, object, object)
			//		что приведет к упаковке char
			return id.ToString() + ':' + size.ToString();
		}


		private static void ConcatMessageAvoidingBoxingBenchmark()
		{
			for (int i = 0; i < Iterations; i++)
			{
				ConcatMessageAvoidingBoxing(1, 42);
			}
		}
		static string ConcatMessageAvoidingBoxing(int id, int size)
		{
			return id.ToString() + ":" + size.ToString();
		}
		

		private static void FormatMessageWithBoxingBenchmark()
		{
			for (int i = 0; i < Iterations; i++)
			{
				FormatMessageWithBoxing(1, 42);
			}
		}
		static string FormatMessageWithBoxing(int id, int size)
		{
			return string.Format("{0}:{1}", id, size);
		}


		private static void FormatMessageAvoidingBoxingBenchmark()
		{
			for (int i = 0; i < Iterations; i++)
			{
				FormatMessageAvoidingBoxing(1, 42);
			}
		}
		static string FormatMessageAvoidingBoxing(int id, int size)
		{
			return string.Format("{0}:{1}", id.ToString(), size.ToString());
		}
	}
}
