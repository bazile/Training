using System;
using System.Runtime.InteropServices;

namespace L03_S01_IDisposable
{
	class Program
	{
		static void Main()
		{
			#region Пример using/IDisposable

			using (Resource r = new Resource())
			{
			    // код внутри using() { ... }
			}

			#region Код генерируемый компилятором для блока using () { .... }

			//{
			//	Resource r = new Resource();
			//	try
			//	{
			//		// код внутри using() { ... }
			//	}
			//	finally
			//	{
			//		r.Dispose();
			//	}
			//}

			#endregion

			#endregion

			#region Пример using/IDisposable с object initializer

			//using (Resource r = new Resource())
			//{
			//	r.ThrowException = true;
			//	// код внутри using() { ... }
			//}

			#region Код генерируемый компилятором для блока using () { .... }

			//{
			//	Resource r = new Resource();
			//	r.ThrowException = false;
			//	try
			//	{
			//		r.ThrowException = true;
			//		// код внутри using() { ... }
			//	}
			//	finally
			//	{
			//		r.Dispose();
			//	}
			//}

			#endregion

			#endregion
		}
	}

	public class Resource : IDisposable
	{
		private IntPtr _nativeResource = Marshal.AllocHGlobal(100);
		private AnotherResource _managedResource = new AnotherResource();
		private bool _throwException;

		public bool ThrowException
		{
			get { return _throwException; }
			set
			{
				_throwException = value;
				if (_throwException)
				{
					throw new InvalidOperationException("Something went wrong!");
				}
			}
		}

		/// <remarks>Dispose() вызывает Dispose(true)</remarks>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <remarks>
		/// Если класс не владеет неуправляемыми ресурсами, то уберите реализацию
		/// финализатора, но оставьте все остальные методы как есть.
		/// </remarks>
		~Resource()
		{
			Dispose(false);
		}

		/// <remarks>
		/// Вся логика по "очистке" реализуется в этом методе
		/// </remarks>
		protected virtual void Dispose(bool disposing)
		{
			Console.WriteLine("Dispose({0})", disposing);
			if (disposing)
			{
				// Вызываем Dispose() для управляемых ресурсов которыми мы владеем
				// Делаем проверки на null для защиты от возможного повторного вызова Dispose()
				if (_managedResource != null)
				{
					_managedResource.Dispose();
					_managedResource = null;
				}
			}

			// Освобождаем неуправляемые ресурсы
			if (_nativeResource != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(_nativeResource);
				_nativeResource = IntPtr.Zero;
			}
		}
	}

	internal class AnotherResource : IDisposable
	{
		public void Dispose()
		{
		}
	}
}
