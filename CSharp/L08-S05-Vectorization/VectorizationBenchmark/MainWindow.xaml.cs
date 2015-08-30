using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BelhardTraining.LessonThreading
{
	public partial class MainWindow : Window
	{
		const long MAX_POOL_SIZE = 256 * 1024 * 1024; //256 MB
		const int MAX_BUFFER_SIZE = 16 * 1024 * 1024; //16 MB

		public MainWindow()
		{
			InitializeComponent();
		}

		static void RandomizeArray(float[] numbers)
		{
			RandomizeArray(numbers, Environment.TickCount);
		}

		static void RandomizeArray(float[] numbers, int seed)
		{
			var rnd = new Random(seed);
			for (int i = 0; i < numbers.Length; i++)
			{
				numbers[i] = (float)(rnd.NextDouble() * rnd.Next(-100, 101));
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			const int N = 7250000*8;
			//if (!AssertN(N)) return;

			int seed = Environment.TickCount;
			var rnd = new Random(seed);
			float[] a = new float[N], b = new float[N];
			RandomizeArray(a, seed);
			RandomizeArray(b);

			Stopwatch watch = Stopwatch.StartNew();
			for (int i = 0; i < N; i++)
			{
				a[i] += b[i];
			}
			watch.Stop();
			long elapsed1 = watch.ElapsedMilliseconds;
			float avg1 = a.Average();

			GC.GetTotalMemory(true);

			//RandomizeArray(a, seed);
			//watch = Stopwatch.StartNew();
			//Parallel.For(0, N, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount}, i => a[i] += b[i]);
			//watch.Stop();
			//long elapsed2 = watch.ElapsedMilliseconds;
			RandomizeArray(a, seed);
			watch = Stopwatch.StartNew();
			Thread[] threads = new Thread[Environment.ProcessorCount];
			int len = N/Environment.ProcessorCount;
			for (int i = 0; i < threads.Length; i++)
			{
				threads[i] = new Thread(data =>
				{
					for (int jj = 0, ii = (int)data; ii < N && jj < len; ii++, jj++)
					{
						a[ii] += b[ii];
					}
				});
				threads[i].Start(i*len);
			}
			foreach (var thread in threads) thread.Join();
			watch.Stop();
			long elapsed2 = watch.ElapsedMilliseconds;
			float avg2 = a.Average();

			RandomizeArray(a, seed);
			watch = Stopwatch.StartNew();
			Yeppp.Core.Add_IV32fV32f_IV32f(a, 0, b, 0, N);
			watch.Stop();
			long elapsed3 = watch.ElapsedMilliseconds;
			float avg3 = a.Average();

			//RandomizeArray(a, seed);
			//watch = Stopwatch.StartNew();
			//threads = new Thread[Environment.ProcessorCount];
			//len = N / Environment.ProcessorCount;
			//for (int i = 0; i < threads.Length; i++)
			//{
			//	threads[i] = new Thread(data =>
			//	{
			//		int ii = (int)data;
			//		int count = len + ii > a.Length ? a.Length - ii : len;
			//		Yeppp.Core.Add_IV32fV32f_IV32f(a, ii, b, ii, count);
			//	});
			//	threads[i].Start(i * len);
			//}
			//foreach (var thread in threads) thread.Join();
			//watch.Stop();
			//long elapsed4 = watch.ElapsedMilliseconds;
			//float avg4 = a.Average();

			bool correct = avg1 == avg2 && avg2 == avg3;// && avg3 == avg4;
			MessageBox.Show(Tuple.Create(elapsed1, elapsed2, elapsed3, correct).ToString());

			//System.Numerics.Vector.LessThan()

			//Yeppp.Math.

			//for (int i = 0; i < N; i+=4)
			//{
			//	Vector4 va = new Vector4(a[i], a[i+1], a[i+2], a[i+3]);
			//	Vector4 vb = new Vector4(b[i], b[i + 1], b[i + 2], b[i + 3]);
			//	Vector4 vc = va + vb;

			//	vc.CopyTo(c, i);
			//}
		}

		//static long Measure(Action action)
		//{

		//}

		//static bool AssertN(int n)
		//{
		//	if (n%4 != 0)
		//	{
		//		MessageBox.Show("Кол-во итеарций должно быть кратно 4", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
		//		return false;
		//	}
		//	return true;
		//}
	}
}
