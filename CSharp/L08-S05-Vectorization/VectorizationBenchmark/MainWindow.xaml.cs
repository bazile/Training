using System;
using System.Numerics;
using System.Security.Cryptography;
using System.ServiceModel.Channels;
using System.Windows;

namespace BelhardTraining.LessonThreading
{
	public partial class MainWindow : Window
	{
		readonly BufferManager _bufferManager;

		const long MAX_POOL_SIZE = 256 * 1024 * 1024; //256 MB
		const int MAX_BUFFER_SIZE = 16 * 1024 * 1024; //16 MB

		public MainWindow()
		{
			InitializeComponent();

			_bufferManager = BufferManager.CreateBufferManager(MAX_POOL_SIZE, MAX_BUFFER_SIZE);
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			const int N = 100;
			if (!AssertN(N)) return;

			var rng = new RNGCryptoServiceProvider();
			byte[] randomData = _bufferManager.TakeBuffer(N*4);
			float[] a = new float[N], b = new float[N], c = new float[N];

			rng.GetNonZeroBytes(randomData);
			Buffer.BlockCopy(randomData, 0, a, 0, N*4);
			rng.GetNonZeroBytes(randomData);
			Buffer.BlockCopy(randomData, 0, b, 0, N*4);

			_bufferManager.ReturnBuffer(randomData);

			for (int i = 0; i < N; i+=4)
			{
				Vector4 va = new Vector4(a[i], a[i+1], a[i+2], a[i+3]);
				Vector4 vb = new Vector4(b[i], b[i + 1], b[i + 2], b[i + 3]);
				Vector4 vc = va + vb;

				vc.CopyTo(c, i);
			}
		}

		static bool AssertN(int n)
		{
			if (n%4 != 0)
			{
				MessageBox.Show("Кол-во итеарций должно быть кратно 4", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			return true;
		}

		protected override void OnClosed(EventArgs e)
		{
			_bufferManager.Clear();
			base.OnClosed(e);
		}
	}
}
