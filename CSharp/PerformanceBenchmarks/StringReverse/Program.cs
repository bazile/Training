using System;
using System.Linq;
using System.Text;
using BelhardTraining.Benchmark.Core;

namespace StringReverse
{
	class Program : ProgramBase
	{
		private const int Iterations = 100;
		private static readonly string TestString = new string('й', 2500);

		private static void Main(string[] args)
		{
			string benchmarkId = args.Length == 1 ? args[0] : null;
			var competition = (new Program()).GetBenchmarkCompetition(benchmarkId);
			competition.Run();
		}

		protected override Tuple<string, string, Action>[] GetBenhmarkList()
		{
			return new[] {
				Tuple.Create<string, string, Action>("VeryBadReverse" , "Очень плохо №1", VeryBadReverseBenchmark),
				Tuple.Create<string, string, Action>("StillBadReverse", "Очень плохо №2", StillBadReverseBenchmark),
				Tuple.Create<string, string, Action>("LinqReverse"    , "Плохо (LINQ)"  , LinqReverseBenchmark),
				Tuple.Create<string, string, Action>("GoodReverse"    , "Хорошо"        , GoodReverseBenchmark),
				Tuple.Create<string, string, Action>("Reverse"        , "Отлично"       , ReverseBenchmark)
			};
		}

		// TODO: Add benchmark for recursion
        static string RecursionReverse(string str)
        {
            if (str.Length == 0) return "";
            if (str.Length == 1) return str;
            return str[str.Length-1] + Reverse(str.Substring(0, str.Length-1));
        }


		/// <summary>Очень плохая реализация разворота строки</summary>
		private static string VeryBadReverse(string s)
		{
			// Ненужное действие. Строка и так является массивом символов
			char[] chars = s.ToCharArray();

			string reveresed = "";
			for (int i = chars.Length; i > 0; i--)
			{
				// Каждое приклеивание символа создает копию строки что и портит производительность
				reveresed += chars[i - 1];
			}
			return reveresed;
		}

		static void VeryBadReverseBenchmark()
		{
			for (int i = 0; i < Iterations; i++)
			{
				VeryBadReverse(TestString);
			}
		}
	
		#region StillBadReverse

		/// <summary>Всё еще плохая реализация разворота строки</summary>
		/// <remarks>В данной реализации нет вызова ToCharArray(), но всё еще есть лишние выделения памяти</remarks>
		private static string StillBadReverse(string s)
		{
			string reveresed = "";
			for (int i = s.Length; i > 0; i--)
			{
				// Каждое приклеивание символа создает копию строки что и портит производительность
				reveresed += s[i - 1];
			}
			return reveresed;
		}

		static void StillBadReverseBenchmark()
		{
			for (int i = 0; i < Iterations; i++)
			{
				StillBadReverse(TestString);
			}
		}

		#endregion
	
		#region LINQ reverse

		private static string LinqReverse(string s)
		{
			return string.Join("", s.Reverse());
		}

		static void LinqReverseBenchmark()
		{
			for (int i = 0; i < Iterations; i++)
			{
				LinqReverse(TestString);
			}
		}

		#endregion

		#region GoodReverse

		/// <summary>Хорошая реализация переворота строки, но место для улучшения еще есть!</summary>
		static string GoodReverse(string s)
		{
			var sb = new StringBuilder();
			for (int i = s.Length; i > 0; i--)
			{
				sb.Append(s[i - 1]);
			}
			return sb.ToString();
		}

		static void GoodReverseBenchmark()
		{
			for (int i = 0; i < Iterations; i++)
			{
				GoodReverse(TestString);
			}
		}

		#endregion

		/// <summary>Самая эффективная реализация переворота строки</summary>
		static string Reverse(string s)
		{
			// Передаем конструктору длину строки чтобы он сразу выделил char[] нужной длины
			// Так следует поступать всегда когда длина результата точно известна или есть примерная оценка итоговой длины
			var sb = new StringBuilder(s.Length);

			for (int i = s.Length; i > 0; i--)
			{
				sb.Append(s[i - 1]);
			}
			return sb.ToString();
		}

		static void ReverseBenchmark()
		{
			for (int i = 0; i < Iterations; i++)
			{
				Reverse(TestString);
			}
		}
	}
}
