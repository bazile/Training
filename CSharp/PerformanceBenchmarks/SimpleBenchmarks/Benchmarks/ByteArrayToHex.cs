using System.Text;
using BenchmarkDotNet.Attributes;

namespace SimpleBenchmarks.Benchmarks
{
    //[LegacyJitX86Job, LegacyJitX64Job, RyuJitX64Job]
    public class ByteArrayToHex
    {
        const int N = 500;
        byte[] array;
        static string[] hexNumbers;

        static ByteArrayToHex()
        {
            hexNumbers = new string[256];
            for (int i = 0; i < 256; i++)
            {
                hexNumbers[i] = i.ToString("X2");
            }
        }

        public ByteArrayToHex()
        {
            array = new byte[N];
        }

        [Benchmark]
        public string StrConcat()
        {
            string s = null;
            for (int i = 0; i < N; i++)
            {
                s += array[i].ToString("X2");
            }
            return s;
        }

        [Benchmark]
        public string StrBuilderBox()
        {
            var sb = new StringBuilder(array.Length * 2);
            for (int i = 0; i < N; i++)
            {
                sb.AppendFormat("{0:X2}", array[i]);
            }
            return sb.ToString();
        }

        [Benchmark]
        public string StrBuilder()
        {
            var sb = new StringBuilder(array.Length * 2);
            for (int i = 0; i < N; i++)
            {
                sb.Append(array[i].ToString("X2"));
            }
            return sb.ToString();
        }

        [Benchmark]
        public string StrBuilderPre()
        {
            var sb = new StringBuilder(array.Length*2);
            for (int i = 0; i < N; i++)
            {
                sb.Append(hexNumbers[array[i]]);
            }
            return sb.ToString();
        }

        [Benchmark(Baseline=true)]
        public string CharArrPre()
        {
            char[] chars = new char[array.Length*2];
            for (int i = 0, j = 0; i < N; i++)
            {
                string s = hexNumbers[array[i]];
                chars[j++] = s[0];
                chars[j++] = s[1];
            }
            return new string(chars);
        }

        // TODO Try Span<char>
    }
}
