using System.Collections;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace SimpleBenchmarks.Benchmarks
{
    [MemoryDiagnoser]
    [StdDevColumn()]
    public class ArrayListVsList
    {
        //[Params(400, 20_000, 100_000, 500_000)]
        public int N = 400;

        [Benchmark]
        public ArrayList ArrayList()
        {
            var list = new ArrayList();
            for (int i = 0; i < N; i++)
            {
                list.Add(N);
            }
            return list;
        }

        [Benchmark]
        public ArrayList ArrayListFixed()
        {
            var list = new ArrayList(N);
            for (int i = 0; i < N; i++)
            {
                list.Add(N);
            }
            return list;
        }

        [Benchmark]
        public List<int> List()
        {
            var list = new List<int>();
            for (int i = 0; i < N; i++)
            {
                list.Add(N);
            }
            return list;
        }

        [Benchmark(Baseline=true)]
        public List<int> ListFixed()
        {
            var list = new List<int>(N);
            for (int i = 0; i < N; i++)
            {
                list.Add(N);
            }
            return list;
        }
    }
}
