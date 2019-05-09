using System.Collections;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace SimpleBenchmarks.Benchmarks
{
    public class IndexOf_vs_Manual
    {
        string _str;

        public IndexOf_vs_Manual()
        {
            _str = new string('o', 10240000) + "<tag>";
        }

        [Benchmark]
        public int IndexOf()
        {
            return _str.IndexOf("<tag>");
        }

        [Benchmark(Baseline = true)]
        public int Manual()
        {
            int len = _str.Length - 4;
            int index = -1;
            for (int i = 0; i < len; i++)
            {
                if (_str[i] == '<' && _str[i + 1] == 't' && _str[i + 2] == 'a' && _str[i + 3] == 'g' && _str[i + 4] == '>')
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
