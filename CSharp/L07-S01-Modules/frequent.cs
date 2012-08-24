using System;

namespace MyAssembly
{
	public delegate string FrequentlyUsedDelegate(int x, double y);
	
	public class FrequentlyUsedClass
	{
		private int _privateInstanceVariable;
		
		public string PublicProperty { get; protected set; }
		
		public event FrequentlyUsedDelegate ImportantEvent;
	}
}
