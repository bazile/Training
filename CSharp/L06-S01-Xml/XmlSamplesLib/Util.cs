using System;
using System.IO;
using System.Reflection;

namespace XmlSamples.Shared
{
    public static class Util
    {
		public static string GetPathToCustomersXml()
		{
			Assembly asm = Assembly.GetExecutingAssembly();

			// Assembly.CodeBase имеет вид file://c:\SomeFolder\Assembly.dll
			string assemblyPath = new Uri(asm.CodeBase).LocalPath;

			string customersXmlPath = Path.Combine(Path.GetDirectoryName(assemblyPath), @"..\..\..\Shared\customers.xml");
			customersXmlPath = Path.GetFullPath(customersXmlPath);

			return customersXmlPath;
		}
    }
}
