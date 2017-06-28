using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;

namespace CultureExplorer.WinForms
{
	class CultureExplorerTypeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (typeof(string) == sourceType) return true;
			throw new NotImplementedException();
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			throw new NotImplementedException();
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			throw new NotImplementedException();
		}

		public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
		{
			throw new NotImplementedException();
		}

		public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
		{
			return false;
		}

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			return TypeDescriptor.GetProperties(value, attributes);
		}

		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return null;
		}

		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return false;
		}

		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return false;
		}

		public override bool IsValid(ITypeDescriptorContext context, object value)
		{
			return false;
		}
	}

	class CalendarTypeConverter : CultureExplorerTypeConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType != typeof(string)) return base.ConvertTo(context, culture, value, destinationType);

			var c = (Calendar) value;
			string s = c.GetType().Name;
			s += ", " + c.AlgorithmType.ToString();
			s = s.Replace("Calendar", "");
			return s;
		}
	}

	class CompareExplorerTypeConverter : CultureExplorerTypeConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType != typeof(string)) return base.ConvertTo(context, culture, value, destinationType);

			var ci = (CompareInfo) value;
			return ci.Name;
		}
		
	}

	class DateTimeFormatExplorerTypeConverter : CultureExplorerTypeConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType != typeof(string)) return base.ConvertTo(context, culture, value, destinationType);

			var dtmi = (DateTimeFormatInfo) value;
			return dtmi.FullDateTimePattern;
		}
	}

	class NumberFormatExplorerTypeConverter : CultureExplorerTypeConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType != typeof(string)) return base.ConvertTo(context, culture, value, destinationType);

			var nfi = (NumberFormatInfo) value;
			return nfi.CurrencySymbol;
		}
	}

	class TextExplorerTypeConverter : CultureExplorerTypeConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType != typeof(string)) return base.ConvertTo(context, culture, value, destinationType);

			var ti = (TextInfo) value;
			return ti.ANSICodePage.ToString();
		}
	}
}
