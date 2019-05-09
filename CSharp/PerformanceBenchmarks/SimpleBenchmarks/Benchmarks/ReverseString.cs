using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace SimpleBenchmarks.Benchmarks
{
    public class ReverseString
    {
        const int LEN = 2500;
        string s;

        public ReverseString()
        {
            s = new string('й', LEN);
        }

        /// <summary>Очень плохая реализация разворота строки</summary>
        [Benchmark]
        public string VeryBadReverse()
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
        [Benchmark]
        public string StillBadReverse()
        {
            string reveresed = "";
            for (int i = s.Length; i > 0; i--)
            {
                // Каждое приклеивание символа создает копию строки что и портит производительность
                reveresed += s[i - 1];
            }
            return reveresed;
        }

        [Benchmark]
        public string LinqReverse()
        {
            return string.Join("", s.Reverse());
        }

        /// <summary>Хорошая реализация переворота строки, но место для улучшения еще есть!</summary>
        [Benchmark]
        public string GoodReverse()
        {
            var sb = new StringBuilder();
            for (int i = s.Length; i > 0; i--)
            {
                sb.Append(s[i - 1]);
            }
            return sb.ToString();
        }

        /// <summary>Самая эффективная реализация переворота строки</summary>
        [Benchmark(Baseline=true)]
        public string Reverse()
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
