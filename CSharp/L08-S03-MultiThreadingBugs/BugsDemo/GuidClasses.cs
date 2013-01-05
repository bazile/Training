using System;

namespace BugsDemo
{
	internal class ClassWithNonAtomicGuidAccess
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

	internal class ClassWithAtomicGuidAccess
	{
		private Guid _value;
		private static object _syncRoot = new object();

		public void SetValue(Guid value)
		{
			lock (_syncRoot)
			{
				_value = value;
			}
		}

		public Guid GetValue()
		{
			lock (_syncRoot)
			{
				return _value;
			}
		}
	}
}
