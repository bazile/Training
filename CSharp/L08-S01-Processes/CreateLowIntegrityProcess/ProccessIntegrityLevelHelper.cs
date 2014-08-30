using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BelhardTraining.LessonMultithreading
{
	public static class ProccessIntegrityLevelHelper
	{
		public static IntegrityLevel GetCurrentProcessIntegrityLevel()
		{
			return GetProcessIntegrityLevel(Process.GetCurrentProcess().Handle);
		}

		public static IntegrityLevel GetProcessIntegrityLevel(IntPtr processHandle)
		{
			IntegrityLevel il;

			SafeTokenHandle hToken = null;
			IntPtr pTokenIL = IntPtr.Zero;

			try
			{
				// Open the access token of the current process with TOKEN_QUERY.
				if (!NativeMethods.OpenProcessToken(processHandle, NativeMethods.TOKEN_QUERY, out hToken))
				{
					throw new Win32Exception();
				}

				// Then we must query the size of the integrity level information 
				// associated with the token. Note that we expect GetTokenInformation 
				// to return false with the ERROR_INSUFFICIENT_BUFFER error code 
				// because we've given it a null buffer. On exit cbTokenIL will tell 
				// the size of the group information.
				int cbTokenIL;
				if (!NativeMethods.GetTokenInformation(hToken,
					TOKEN_INFORMATION_CLASS.TokenIntegrityLevel, IntPtr.Zero, 0,
					out cbTokenIL))
				{
					int error = Marshal.GetLastWin32Error();
					if (error != NativeMethods.ERROR_INSUFFICIENT_BUFFER)
					{
						// When the process is run on operating systems prior to 
						// Windows Vista, GetTokenInformation returns false with the 
						// ERROR_INVALID_PARAMETER error code because 
						// TokenIntegrityLevel is not supported on those OS's.
						throw new Win32Exception(error);
					}
				}

				// Now we allocate a buffer for the integrity level information.
				pTokenIL = Marshal.AllocHGlobal(cbTokenIL);
				if (pTokenIL == IntPtr.Zero)
				{
					throw new Win32Exception();
				}

				// Now we ask for the integrity level information again. This may fail 
				// if an administrator has added this account to an additional group 
				// between our first call to GetTokenInformation and this one.
				if (!NativeMethods.GetTokenInformation(hToken,
					TOKEN_INFORMATION_CLASS.TokenIntegrityLevel, pTokenIL, cbTokenIL,
					out cbTokenIL))
				{
					throw new Win32Exception();
				}

				// Marshal the TOKEN_MANDATORY_LABEL struct from native to .NET object.
				var tokenIL = (TOKEN_MANDATORY_LABEL)Marshal.PtrToStructure(pTokenIL, typeof(TOKEN_MANDATORY_LABEL));

				// Integrity Level SIDs are in the form of S-1-16-0xXXXX. (e.g. 
				// S-1-16-0x1000 stands for low integrity level SID). There is one 
				// and only one subauthority.
				IntPtr pIL = NativeMethods.GetSidSubAuthority(tokenIL.Label.Sid, 0);
				switch (Marshal.ReadInt32(pIL))
				{
					case NativeMethods.SECURITY_MANDATORY_UNTRUSTED_RID:
						il = IntegrityLevel.Untrusted; break;
					case NativeMethods.SECURITY_MANDATORY_LOW_RID:
						il = IntegrityLevel.Low; break;
					case NativeMethods.SECURITY_MANDATORY_MEDIUM_RID:
						il = IntegrityLevel.Medium; break;
					case NativeMethods.SECURITY_MANDATORY_HIGH_RID:
						il = IntegrityLevel.High; break;
					case NativeMethods.SECURITY_MANDATORY_SYSTEM_RID:
						il = IntegrityLevel.System; break;
					default:
						il = IntegrityLevel.Unknown; break;
				}
			}
			finally
			{
				// Очищаем неуправляемые ресурсы
				if (hToken != null)
				{
					hToken.Close();
				}
				if (pTokenIL != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(pTokenIL);
				}
			}

			return il;
		}

		/// <summary>
		/// The function launches an application at low integrity level. 
		/// </summary>
		/// <param name="commandLine">
		/// The command line to be executed. The maximum length of this string is 32K 
		/// characters. 
		/// </param>
		/// <remarks>
		/// To start a low-integrity process, 
		/// 1) Duplicate the handle of the current process, which is at medium 
		///    integrity level.
		/// 2) Use SetTokenInformation to set the integrity level in the access token 
		///    to Low.
		/// 3) Use CreateProcessAsUser to create a new process using the handle to 
		///    the low integrity access token.
		/// </remarks>
		public static void CreateLowIntegrityProcess(string commandLine)
		{
			SafeTokenHandle hToken = null;
			SafeTokenHandle hNewToken = null;
			IntPtr pIntegritySid = IntPtr.Zero;
			IntPtr pTokenInfo = IntPtr.Zero;
			STARTUPINFO si = new STARTUPINFO();
			PROCESS_INFORMATION pi = new PROCESS_INFORMATION();

			try
			{
				// Open the primary access token of the process.
				if (!NativeMethods.OpenProcessToken(Process.GetCurrentProcess().Handle,
					NativeMethods.TOKEN_DUPLICATE | NativeMethods.TOKEN_ADJUST_DEFAULT |
					NativeMethods.TOKEN_QUERY | NativeMethods.TOKEN_ASSIGN_PRIMARY,
					out hToken))
				{
					throw new Win32Exception();
				}

				// Duplicate the primary token of the current process.
				if (!NativeMethods.DuplicateTokenEx(hToken, 0, IntPtr.Zero,
					SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, 
					TOKEN_TYPE.TokenPrimary, out hNewToken))
				{
					throw new Win32Exception();
				}

				// Create the low integrity SID.
				if (!NativeMethods.AllocateAndInitializeSid(
					ref NativeMethods.SECURITY_MANDATORY_LABEL_AUTHORITY, 1, 
					NativeMethods.SECURITY_MANDATORY_LOW_RID,
					0, 0, 0, 0, 0, 0, 0, out pIntegritySid))
				{
					throw new Win32Exception();
				}

				TOKEN_MANDATORY_LABEL tml;
				tml.Label.Attributes = NativeMethods.SE_GROUP_INTEGRITY;
				tml.Label.Sid = pIntegritySid;

				// Marshal the TOKEN_MANDATORY_LABEL struct to the native memory.
				int cbTokenInfo = Marshal.SizeOf(tml);
				pTokenInfo = Marshal.AllocHGlobal(cbTokenInfo);
				Marshal.StructureToPtr(tml, pTokenInfo, false);

				// Set the integrity level in the access token to low.
				if (!NativeMethods.SetTokenInformation(hNewToken,
					TOKEN_INFORMATION_CLASS.TokenIntegrityLevel, pTokenInfo,
					cbTokenInfo + NativeMethods.GetLengthSid(pIntegritySid)))
				{
					throw new Win32Exception();
				}

				// Create the new process at the Low integrity level.
				si.cb = Marshal.SizeOf(si);
				if (!NativeMethods.CreateProcessAsUser(hNewToken, null, commandLine, 
					IntPtr.Zero, IntPtr.Zero, false, 0, IntPtr.Zero, null, ref si, 
					out pi))
				{
					throw new Win32Exception();
				}
			}
			finally
			{
				// Centralized cleanup for all allocated resources. 
				if (hToken != null)
				{
					hToken.Close();
				}
				if (hNewToken != null)
				{
					hNewToken.Close();
				}
				if (pIntegritySid != IntPtr.Zero)
				{
					NativeMethods.FreeSid(pIntegritySid);
				}
				if (pTokenInfo != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(pTokenInfo);
				}
				if (pi.hProcess != IntPtr.Zero)
				{
					NativeMethods.CloseHandle(pi.hProcess);
					pi.hProcess = IntPtr.Zero;
				}
				if (pi.hThread != IntPtr.Zero)
				{
					NativeMethods.CloseHandle(pi.hThread);
					pi.hThread = IntPtr.Zero;
				}
			}
		}
	}
}
