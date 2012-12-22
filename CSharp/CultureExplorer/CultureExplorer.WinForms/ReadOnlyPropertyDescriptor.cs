using System;
using System.ComponentModel;
using System.Reflection;

namespace CultureExplorer.WinForms
{
	internal class ReadOnlyPropertyDescriptor<T> : PropertyDescriptor
	{
		public ReadOnlyPropertyDescriptor(string name, Attribute[] attrs) : base(name, attrs)
		{
		}

		public ReadOnlyPropertyDescriptor(MemberDescriptor descr) : base(descr)
		{
		}

		public ReadOnlyPropertyDescriptor(MemberDescriptor descr, Attribute[] attrs) : base(descr, attrs)
		{
		}

		public override bool CanResetValue(object component)
		{
			return false;
		}

		public override Type ComponentType
		{
			get { return typeof(T); }
		}

		public override object GetValue(object component)
		{
			PropertyInfo pi = ComponentType.GetProperty(Name);
			return pi.GetValue(component, null);
		}

		public override bool IsReadOnly
		{
			get { return true; }
		}

		public override Type PropertyType
		{
			get { return ComponentType.GetProperty(Name).PropertyType; }
		}

		public override void ResetValue(object component)
		{
		}

		public override void SetValue(object component, object value)
		{
		}

		public override bool ShouldSerializeValue(object component)
		{
			return false;
		}
	}
}
