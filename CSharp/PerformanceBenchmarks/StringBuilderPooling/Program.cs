using System;
using System.Text;
using BelhardTraining.Benchmark.Core;
using BenchmarkDotNet;

namespace StringBuilderPooling
{
	class Program : ProgramBase
	{
		private static int iterations = 1000000;

		static void Main(string[] args)
		{
			string benchmarkId = args.Length == 1 ? args[0] : null;
			var competition = (new Program()).GetBenchmarkCompetition(benchmarkId);
			competition.Run();
		}

		protected override Tuple<string, string, Action>[] GetBenhmarkList()
		{
			return new[] {
				Tuple.Create<string, string, Action>("NoPooling" , "Без пула", NoPoolingBenchmark),
				Tuple.Create<string, string, Action>("UsePooling", "С пулом" , UsePoolingBenchmark)
			};
		}

		#region Без пула

		static void NoPoolingBenchmark()
		{
			for (int i = 0; i < iterations; i++)
			{
				GenerateFullTypeName("Something", 5);
			}
		}

		public static string GenerateFullTypeName(string name, int arity)
		{
			var sb = new StringBuilder();
			sb.Append(name);
			if (arity > 0)
			{
				sb.Append("<");
				for (int i = 1; i < arity; i++)
				{
					sb.Append('T');
					sb.Append(i.ToString());
					sb.Append(", ");
				}
				sb.Append('T');
				sb.Append(arity.ToString());
				sb.Append(">");
			}
			return sb.ToString();
		}

		#endregion

		#region С пулом

		static void UsePoolingBenchmark()
		{
			for (int i = 0; i < iterations; i++)
			{
				PoolingImpl.GenerateFullTypeNameCached("Something", 5);
			}
		}

		private static class PoolingImpl
		{
			[ThreadStatic]
			private static StringBuilder _cachedStringBuilder;

			private static StringBuilder AcquireBuilder()
			{
				StringBuilder sb = _cachedStringBuilder;
				if (sb == null)
				{
					return new StringBuilder();
				}
				sb.Clear();
				_cachedStringBuilder = null;
				return sb;
			}

			private static string GetStringAndReleaseBuilder(StringBuilder sb)
			{
				string result = sb.ToString();
				_cachedStringBuilder = sb;
				return result;
			}

			public static string GenerateFullTypeNameCached(string name, int arity)
			{
				var sb = AcquireBuilder();
				sb.Append(name);
				if (arity > 0)
				{
					sb.Append("<");
					for (int i = 1; i < arity; i++)
					{
						sb.Append('T');
						sb.Append(i.ToString());
						sb.Append(", ");
					}
					sb.Append('T');
					sb.Append(arity.ToString());
					sb.Append(">");
				}
				return GetStringAndReleaseBuilder(sb);
			}
		}

		#endregion
	}
}
