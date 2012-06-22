using CPlusPlusLibrary;
using FSharpLibrary;
using VisualBasicLibrary;

namespace ConsoleApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			VisualBasicClass.WriteMessage();
			FSharpClass.WriteMessage();
			CPlusPlusClass.WriteMessage();
		}
	}
}
