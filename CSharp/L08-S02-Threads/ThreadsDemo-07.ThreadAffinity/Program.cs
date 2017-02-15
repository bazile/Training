using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;

/*
 * Демонстрация установки thread affinity (маски предпочтительных процессоров)
*/

namespace ThreadsDemo_07.ThreadAffinity
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Environment.ProcessorCount == 1)
            {
                Console.WriteLine("Для демонстрации необходимо несколько процессов");
                return;
            }

            Thread[] threads = new Thread[Environment.ProcessorCount];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(LongOperation);
                threads[i].Start();
            }
        }

        static int CurrentProcessor = -1;

        static void LongOperation()
        {
            int currProc = Interlocked.Increment(ref CurrentProcessor);
            ThreadHelper.SetThreadProcessorAffinity(new UIntPtr(1U << currProc));

            // Пауза перед работой чтобы все потоки успели запуститься
            Thread.Sleep(500);

            int i = 0;
            for (; i < 1000000; i++) ;
            Console.WriteLine(i);
        }
    }

    static class ThreadHelper
    {
        [System.Security.SecuritySafeCritical]
        [HostProtection(SelfAffectingThreading = true)]
        public static void SetThreadProcessorAffinity(UIntPtr affinity)
        {
            Thread.BeginThreadAffinity();

            IntPtr hThread = Native.GetCurrentThread();
            Native.SetThreadAffinityMask(hThread, affinity);
        }

        static class Native
        {
            [DllImport("kernel32.dll")]
            public static extern IntPtr GetCurrentThread();

            [HostProtectionAttribute(SelfAffectingThreading = true)]
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern UIntPtr SetThreadAffinityMask(IntPtr handle, UIntPtr mask);

            ///<summary>Sets a preferred processor for a thread. The system schedules threads on their preferred processors whenever possible.</summary>
            ///<param name="hThread">A handle to the thread whose preferred processor is to be set.</param>
            ///<param name="dw">The number of the preferred processor for the thread. This value is zero-based.</param>
            [HostProtectionAttribute(SelfAffectingThreading = true)]
            [DllImport("kernel32.dll")]
            public static extern uint SetThreadIdealProcessor(IntPtr hThread, uint dwIdealProcessor);
        }
    }
}
