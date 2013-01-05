using System;

namespace BugsDemo
{
	internal class AtomicityExample
	{
		private Guid _value;

		public void SetValue(Guid value)
		{
			_value = value;
		}

		public Guid GetValue()
		{
			return _value;
		}
	}
}
