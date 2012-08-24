using System;

namespace MyAssembly
{
	public delegate string RareUsedDelegate(int x, double y);
	
	public class RareUsedClass
	{
		private int _privateInstanceVariable;
		
		public string PublicProperty { get; protected set; }
		
		public event RareUsedDelegate ImportantEvent;
	}
}
