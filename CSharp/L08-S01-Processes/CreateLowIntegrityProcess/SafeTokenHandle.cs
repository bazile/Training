using System;
using Microsoft.Win32.SafeHandles;

namespace TrainingCenter.LessonMultithreading
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
            return NativeMethods.CloseHandle(base.handle);
        }
    }
}
