using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TrainingCenter.LessonThreading
{
	static class NativeHelper
	{
		[Conditional("DEBUG")]
		public static void DisableWindowsErrorReporting()
		{
			SetErrorMode(
				SetErrorMode(ErrorModes.SYSTEM_DEFAULT)
				| ErrorModes.SEM_NOGPFAULTERRORBOX | ErrorModes.SEM_FAILCRITICALERRORS | ErrorModes.SEM_NOOPENFILEERRORBOX
			);
		}

		#region Native methods

		[DllImport("kernel32.dll")]
		static extern ErrorModes SetErrorMode(ErrorModes mode);

		[Flags]
		enum ErrorModes : uint
		{
			SYSTEM_DEFAULT = 0x0,
			SEM_FAILCRITICALERRORS = 0x0001,
			SEM_NOALIGNMENTFAULTEXCEPT = 0x0004,
			SEM_NOGPFAULTERRORBOX = 0x0002,
			SEM_NOOPENFILEERRORBOX = 0x8000
		}

		#endregion

	}
}
