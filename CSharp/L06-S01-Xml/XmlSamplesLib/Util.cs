using System;
using System.IO;
using System.Reflection;

namespace XmlSamples.Shared
{
    public static class Util
    {
		public static string GetPathToCustomersXml()
		{
			return GetFilePathFromSharedFolder("customers.xml");
		}

	    public static string GetPathToCustomersXsd()
	    {
			return GetFilePathFromSharedFolder("customers.xsd");
	    }

		private static string GetFilePathFromSharedFolder(string fileName)
		{
			Assembly asm = Assembly.GetExecutingAssembly();

			// Assembly.CodeBase имеет вид file://c:\SomeFolder\Assembly.dll
			string assemblyPath = new Uri(asm.CodeBase).LocalPath;

			string customersXmlPath = Path.Combine(Path.GetDirectoryName(assemblyPath), @"..\..\..\Shared\" + fileName);
			customersXmlPath = Path.GetFullPath(customersXmlPath);

			return customersXmlPath;
			
		}
    }
}
