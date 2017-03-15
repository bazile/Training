using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TrainingCenter.QuadraticEquationBenchmark
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");

            const int equationCount = 45*1000*1000;

            Console.WriteLine("Решаем квадратные уравнения: {0:N0}", equationCount);
            Console.WriteLine();
            BenchmarkWithoutThreads(equationCount);
            Console.WriteLine();

            BenchmarkWithThreads(equationCount, 2);
            BenchmarkWithThreads(equationCount, 3);
            BenchmarkWithThreads(equationCount, 4);
            Console.WriteLine();

            #region ThreadPriority.Highest

            //BenchmarkWithThreads(equationCount, 2, ThreadPriority.Highest);
            //BenchmarkWithThreads(equationCount, 3, ThreadPriority.Highest);
            //BenchmarkWithThreads(equationCount, 4, ThreadPriority.Highest);
            //Console.WriteLine();

            #endregion

            #region Parallel.For

            //Console.Write("Время на решение с помощью Parallel.ForEach: ");
            //Stopwatch watch = Stopwatch.StartNew();
            //var equations = (new RandomCoeffEnumerator()).Take(equationCount);
            //Parallel.ForEach(
            //    equations,
            //    new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
            //    eq => { Equation tempEq = eq; Solve(ref tempEq); }
            //);
            //watch.Stop();
            //Console.WriteLine("{0:F4} сек.", watch.Elapsed.TotalSeconds);

            #endregion
        }

        /// <summary>
        /// Замеряет и выводит на экран время потраченное на решение уравнений без использования потоков
        /// </summary>
        /// <param name="equationCount">Количество уравнений которые необходимо решить</param>
        //private static void BenchmarkWithoutThreads(Equation[] equations)
        private static void BenchmarkWithoutThreads(int equationCount)
        {
            Console.Write("Время на решение без потоков: ");
            var coeffEnumerator = new RandomCoeffEnumerator().GetEnumerator();
            Stopwatch watch = Stopwatch.StartNew();
            for (int i = 0; i < equationCount; i++)
            {
                coeffEnumerator.MoveNext();
                Equation eq = coeffEnumerator.Current;

                Solve(ref eq);
            }
            watch.Stop();
            Console.WriteLine("{0:F4} сек.", watch.Elapsed.TotalSeconds);
        }

        /// <summary>
        /// Замеряет и выводит на экран время потраченное на решение уравнений с использованием потоков
        /// </summary>
        /// <param name="totalEquationCount">Общее количество уравнений которые необходимо решить. Делится между потоками</param>
        /// <param name="threadCount">Кол-во потоков которые следует использовать для параллельного решения уравнений</param>
        /// <param name="priority">Приоритет потока</param>
        private static void BenchmarkWithThreads(int totalEquationCount, int threadCount, ThreadPriority priority = ThreadPriority.Normal)
        {
            if (totalEquationCount % threadCount != 0) throw new Exception();

            Console.Write("Время на решение  с потоками: ");
            int itemsPerThread = totalEquationCount / threadCount; // Кол-во уравнений для каждого потока

            Stopwatch watch = Stopwatch.StartNew();
            Thread[] solveThreads = new Thread[threadCount];
            for (int i = 0, offset = 0; i < solveThreads.Length; i++, offset += itemsPerThread)
            {
                solveThreads[i] = new Thread(SolveThread)
                {
                    Name = String.Format("Решатель уравнений #{0}", i + 1),
                    Priority = priority
                };
                solveThreads[i].Start(itemsPerThread);
            }
            foreach (Thread solveThread in solveThreads)
            {
                solveThread.Join();
            }
            watch.Stop();
            Console.WriteLine("{0:F4} сек. Кол-во потоков: {1}. Приоритет: {2}", watch.Elapsed.TotalSeconds, threadCount, PriorityToString(priority));
        }

        static string PriorityToString(ThreadPriority priority)
        {
            switch (priority)
            {
                case ThreadPriority.Lowest:
                    return "Самый низкий";
                case ThreadPriority.BelowNormal:
                    return "Ниже нормального";
                case ThreadPriority.Normal:
                    return "Нормальный";
                case ThreadPriority.AboveNormal:
                    return "Выше нормального";
                case ThreadPriority.Highest:
                    return "Самый высокий";
                default:
                    return priority.ToString();
            }
        }

        /// <summary>
        /// Решение квадратного уравнения с двумя коэффециентами
        /// </summary>
        /// <param name="equation"></param>
        static void Solve(ref Equation equation)
        {
            if (equation.B > 0 || equation.B < 0)
            {
                double d = equation.B*equation.B; // Дискриминант
                double sqrt_d = Math.Sqrt(d);
                double a2 = 2*equation.A;
                equation.Solution1 = (sqrt_d - equation.B)/a2;
                equation.Solution2 = (-equation.B - sqrt_d)/a2;
            }
            else
            {
                equation.Solution1 = equation.Solution2 = -equation.B/(2*equation.A);
            }
        }

        static void SolveThread(object data)
        {
            int equationCount = (int)data;
            var coeffEnumerator = new RandomCoeffEnumerator().GetEnumerator();
            for (int i = 0; i < equationCount; i++)
            {
                coeffEnumerator.MoveNext();
                Equation eq = coeffEnumerator.Current;

                Solve(ref eq);
            }
        }
    }
}
