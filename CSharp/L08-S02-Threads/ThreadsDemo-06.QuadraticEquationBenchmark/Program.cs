#define RANDOM_COEFFS // Генерировать случайные коэффециенты для всех уравнений или использовать одинаковые

using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace BelhardTraining.QuadraticEquationBenchmark
{
	class Program
	{
		static void Main()
		{
			Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");

			const int equationCount = 45000000;

			Console.Write("Генерация коэффециентов для {0:N0} уравнений ... ", equationCount);
			Equation[] equations = CreateRandomCoeffs(equationCount);
			Console.WriteLine("Готово.");

			Console.WriteLine();
			BenchmarkWithoutThreads(equations);
			Console.WriteLine();

			BenchmarkWithThreads(equations, 2);
			BenchmarkWithThreads(equations, 3);
			BenchmarkWithThreads(equations, 4);
		}

		/// <summary>
		/// Замеряет и выводит на экран время потраченное на решение уравнений без использования потоков
		/// </summary>
		/// <param name="equations">Уравнения которые необходимо решить</param>
		private static void BenchmarkWithoutThreads(Equation[] equations)
		{
			Stopwatch watch = Stopwatch.StartNew();
			for (int i = 0; i < equations.Length; i++)
			{
				Solve(ref equations[i]);
			}
			watch.Stop();
			Console.WriteLine("Время на решение без потоков: {0:F4} сек.", watch.Elapsed.TotalSeconds);
		}
		
		/// <summary>
		/// Замеряет и выводит на экран время потраченное на решение уравнений с использованием потоков
		/// </summary>
		/// <param name="equations">Уравнения которые необходимо решить</param>
		/// <param name="threadCount">Кол-во потоков которые следует использовать для параллельного решения уравнений</param>
		private static void BenchmarkWithThreads(Equation[] equations, int threadCount)
		{
			int equationCount = equations.Length;
			int itemsPerThread = equations.Length / threadCount; // Кол-во уравнений для каждого потока

			Stopwatch watch = Stopwatch.StartNew();
			Thread[] solveThreads = new Thread[threadCount];
			for (int i = 0, offset = 0; i < solveThreads.Length; i++, offset += itemsPerThread)
			{
				solveThreads[i] = new Thread(SolveThread);
				solveThreads[i].Name = String.Format("Решатель уравнений #{0}", i + 1);

				ArraySegment<Equation> segment;
				if (i == solveThreads.Length - 1 && equationCount % threadCount != 0)
				{
					segment = new ArraySegment<Equation>(equations, offset, itemsPerThread + equationCount % threadCount);
				}
				else
				{
					segment = new ArraySegment<Equation>(equations, offset, itemsPerThread);
				}
				solveThreads[i].Start(segment);
			}
			foreach (Thread solveThread in solveThreads)
			{
				solveThread.Join();
			}
			watch.Stop();
			Console.WriteLine("Время на решение  с потоками: {0:F4} сек. Кол-во потоков: {1}", watch.Elapsed.TotalSeconds, threadCount);
		}

		/// <summary>
		/// Решение квадратного уравнения с двумя коэффециентами
		/// </summary>
		/// <param name="equation"></param>
		static void Solve(ref Equation equation)
		{
			if (equation.B > 0 || equation.B < 0)
			{
				double d = equation.B * equation.B; // Дискриминант
				double sqrt_d = Math.Sqrt(d);
				double a2 = 2 * equation.A;
				equation.Solution1 = (sqrt_d - equation.B) / a2;
				equation.Solution2 = (-equation.B - sqrt_d) / a2;
			}
			else
			{
				equation.Solution1 = equation.Solution2 = -equation.B / (2 * equation.A);
			}
		}

		private static void SolveThread(object data)
		{
			ArraySegment<Equation> segment = (ArraySegment<Equation>)data;
			Equation[] equations = segment.Array;
			int lastOffset = segment.Offset + segment.Count;
			for (int i = segment.Offset; i < lastOffset; i++)
			{
				Solve(ref equations[i]);
			}
		}

		private static Equation[] CreateRandomCoeffs(int count)
		{
			Equation[] coeffs = new Equation[count];

			#if RANDOM_COEFFS

			Random rnd = new Random(Environment.TickCount);

			byte[] randomBytes = new byte[1000];
			Debug.Assert(randomBytes.Length%4 == 0);

			int rndPos = 0;
			for (int i = 0; i < coeffs.Length; i++)
			{
				if (rndPos >= randomBytes.Length)
				{
				    rnd.NextBytes(randomBytes);
				    rndPos = 0;
				}
				coeffs[i].A = randomBytes[rndPos] * randomBytes[rndPos+1];
				coeffs[i].B = randomBytes[rndPos + 2] * randomBytes[rndPos + 3];
			}

			#else

			for (int i = 0; i < coeffs.Length; i++)
			{
				coeffs[i] = new Equation { A = 1, B = 1 };
			}

			#endif

			return coeffs;
		}
	}

	struct Equation
	{
		public double A, B;
		public double Solution1, Solution2;
	}
}
