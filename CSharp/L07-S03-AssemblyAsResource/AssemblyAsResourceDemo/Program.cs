using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace AssemblyAsResourceDemo
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			if (Thread.CurrentThread.CurrentCulture.Name.Equals("ru-RU", StringComparison.OrdinalIgnoreCase))
			{
				Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
			}

			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainOnAssemblyResolve;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}

		static Assembly CurrentDomainOnAssemblyResolve(object sender, ResolveEventArgs args)
		{
			AssemblyName asmName = new AssemblyName(args.Name);
			if (asmName.Name.Equals("Humanizer", StringComparison.OrdinalIgnoreCase))
			{
				return Assembly.Load(LoadResource("Humanizer.dll"));
			}
			else if (
				asmName.Name.Equals("Humanizer.resources", StringComparison.OrdinalIgnoreCase)
				&& asmName.CultureName.Equals("ru", StringComparison.OrdinalIgnoreCase))
			{
				return Assembly.Load(LoadResource("Humanizer-resources-ru.dll"));
			}
			return null;
		}

		static byte[] LoadResource(string name)
		{
			var asm = typeof(Program).Assembly;
			using (var stream = asm.GetManifestResourceStream("AssemblyAsResourceDemo.Resources." + name))
			{
				byte[] buf = new byte[(int)stream.Length];
				stream.Read(buf, 0, buf.Length);
				return buf;
			}
		}
	}
}
