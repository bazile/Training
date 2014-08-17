using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet;

namespace LinqFirstOrDefault
{
	class Program
	{
		private static int iterations = 8000;

		static void Main(string[] args)
		{
			const string nameToFind = "kcw";
			var competition = new BenchmarkCompetition();
			competition.AddTask("LINQ", () => FindSymbolLinqBenchmark(nameToFind));
			competition.AddTask("ForEach", () => FindSymbolForEachBenchmark(nameToFind));
			competition.Run();
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
			for (int i = 0; i < iterations; i++)
			{
				// Delegate allocation
				// boxing of List<T> enumerator
				Symbol symbol = _symbols.FirstOrDefault(s => s.Name == name);
			}
		}

		static void FindSymbolForEachBenchmark(string name)
		{
			for (int i = 0; i < iterations; i++)
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
