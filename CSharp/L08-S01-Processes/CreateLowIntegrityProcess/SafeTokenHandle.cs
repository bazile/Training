using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace BelhardTraining.LessonMultithreading
{
	/// <summary>
	/// Represents a wrapper class for a token handle.
	/// </summary>
	public class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
	{
		// ReSharper disable UnusedMember.Local
		/// <remarks>
		/// Не удаляйте этот конструктор т.к. программа не будет работать без него
		/// </remarks>>
		private SafeTokenHandle()
			: base(true)
		{
		}
		// ReSharper restore UnusedMember.Local

		public SafeTokenHandle(IntPtr handle)
			: base(true)
		{
			base.SetHandle(handle);
		}

		protected override bool ReleaseHandle()
		{
			return CloseHandle(base.handle);
		}

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseHandle(IntPtr handle);
	}
}
