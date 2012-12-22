using System;
using System.ComponentModel;
using System.Diagnostics;

namespace CultureExplorer.WinForms
{
	class CultureExplorerTypeDescriptionProvider<T,TTypeDescriptor> : TypeDescriptionProvider
		where TTypeDescriptor : ICustomTypeDescriptor, new()
	{
		public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
		{
			var t = typeof(T);
			Debug.Assert(objectType == t || t.IsAssignableFrom(objectType));

			return new TTypeDescriptor();
		}
	}
}
