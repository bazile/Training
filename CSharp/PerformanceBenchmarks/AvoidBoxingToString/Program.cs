using BenchmarkDotNet;

namespace AvoidBoxingToString
{
	class Program
	{
		private static int iterations = 3000000;

		static void Main(string[] args)
		{
			var competition = new BenchmarkCompetition();
			competition.AddTask("ConcatObjects", ConcatMessageWithBoxingBenchmark);
			competition.AddTask("ConcatStrings", ConcatMessageAvoidingBoxingBenchmark);
			competition.AddTask("Format1", FormatMessageWithBoxingBenchmark);
			competition.AddTask("Format2", FormatMessageAvoidingBoxingBenchmark);
			competition.Run();
		}
		

		private static void ConcatMessageWithBoxingBenchmark()
		{
			for (int i = 0; i < iterations; i++)
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
			for (int i = 0; i < iterations; i++)
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
			for (int i = 0; i < iterations; i++)
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
			for (int i = 0; i < iterations; i++)
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
