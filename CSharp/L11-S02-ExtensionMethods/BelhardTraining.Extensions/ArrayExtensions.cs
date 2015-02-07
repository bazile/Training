using System;
using System.Text;

namespace BelhardTraining.Extensions
{
	public static class ArrayExtensions
	{
		public static bool CompareTo(this byte[] buf1, byte[] buf2)
		{
			if (ReferenceEquals(buf1, buf2)) return true;
			if ((buf1 == null && buf2 != null) || (buf1 != null && buf2 == null)) return false;
			if (buf1.Length != buf2.Length) return false;

			for (int i = 0; i < buf1.Length; i++) if (buf1[i] != buf2[i]) return false;
			return true;
		}

		public static string ToHexString(this byte[] buf)
		{
			if (buf == null || buf.Length == 0) return "";

			var sb = new StringBuilder(buf.Length*2);
			for (int i = 0; i < buf.Length; i++)
			{
				sb.AppendFormat("{0:X2}", buf[i]);
			}
			return sb.ToString();
		}

		public static string ToHexString(this byte[] buf, char separator)
		{
			if (buf == null || buf.Length == 0) return "";

			var sb = new StringBuilder(buf.Length * 2 + buf.Length);
			for (int i = 0; i < buf.Length; i++)
			{
				sb.AppendFormat("{0:X2}", buf[i]);
				sb.Append(separator);
			}
			sb.Length--;
			return sb.ToString();
		}
	}
}
