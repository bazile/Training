using System;
using System.Collections.Generic;
using System.Linq;
using BelhardTraining.Benchmark.Core;
using BenchmarkDotNet;

namespace LinqFirstOrDefault
{
	class Program : ProgramBase
	{
		private const int Iterations = 8000;
		const string nameToFind = "kcw";

		static void Main(string[] args)
		{
			string benchmarkId = args.Length == 1 ? args[0] : null;
			var competition = (new Program()).GetBenchmarkCompetition(benchmarkId);
			competition.Run();
		}

		protected override Tuple<string, string, Action>[] GetBenhmarkList()
		{
			return new[] {
				Tuple.Create<string, string, Action>("LINQ"   , "Через LINQ"   , () => FindSymbolLinqBenchmark(nameToFind)),
				Tuple.Create<string, string, Action>("ForEach", "Через foreach", () => FindSymbolForEachBenchmark(nameToFind))
			};
		}

		class Symbol
		{
			public Symbol(string name)
			{
				Name = name;
			}

			public string Name { get; private set; }
		}

		static List<Symbol> _symbols = InitSymbols();

		private static List<Symbol> InitSymbols()
		{
			var symbols = new List<Symbol>();
			string[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray().Select(ch => ch.ToString()).ToArray();
			for (int i = 0; i < letters.Length; i++)
			{
				for (int j = 0; j < letters.Length; j++)
				{
					for (int k = 0; k < letters.Length; k++)
					{
						string name = letters[i] + letters[j] + letters[k];
						symbols.Add(new Symbol(name));
					}
				}
			}
			return symbols;
		}

		static void FindSymbolLinqBenchmark(string name)
		{
			for (int i = 0; i < Iterations; i++)
			{
				// Delegate allocation
				// boxing of List<T> enumerator
				Symbol symbol = _symbols.FirstOrDefault(s => s.Name == name);
			}
		}

		static void FindSymbolForEachBenchmark(string name)
		{
			for (int i = 0; i < Iterations; i++)
			{
				Symbol foundSymbol = default(Symbol);
				foreach (var symbol in _symbols)
				{
					if (symbol.Name == name)
					{
						foundSymbol = symbol;
						break;
					}
				}
			}
		}
	}
}
