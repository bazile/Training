using System.Linq;
using System.Text;

namespace StringReverse
{
	partial class Program
	{
		private static int iterations = 100;

		static void Main(string[] args)
		{
			string benchmarkId = args.Length == 1 ? args[0] : null;
			var competition = GetBenchmarkCompetition(benchmarkId);
			competition.Run();
		}

		static readonly string TestString = new string('й', 2500);

		/// <summary>Очень плохая реализация разворота строки</summary>
		static string VeryBadReverse(string s)
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

		/// <summary>Всё еще плохая реализация разворота строки</summary>
		/// <remarks>В данной реализации нет вызова ToCharArray(), но всё еще есть лишние выделения памяти</remarks>
		static string StillBadReverse(string s)
		{
			string reveresed = "";
			for (int i = s.Length; i > 0; i--)
			{
				// Каждое приклеивание символа создает копию строки что и портит производительность
				reveresed += s[i - 1];
			}
			return reveresed;
		}

		static string LinqReverse(string s)
		{
			return string.Join("", s.Reverse());
		}

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
	}
}
