using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using SimpleBenchmarks.Benchmarks;

namespace SimpleBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: remove somme columns
            // TODO: russian language

            //var summary = BenchmarkRunner.Run<ByteArrayToHex>();
            //var summary = BenchmarkRunner.Run<ReverseString>();
            //var config = ManualConfig.Create(DefaultConfig.Instance).With(columns: );

            //var summary = BenchmarkRunner.Run<ArrayListVsList>();

            var summary = BenchmarkRunner.Run<IndexOf_vs_Manual>();
        }
    }
}
