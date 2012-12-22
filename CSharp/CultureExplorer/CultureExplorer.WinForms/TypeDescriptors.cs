using System;
using System.ComponentModel;
using System.Globalization;

namespace CultureExplorer.WinForms
{
	abstract class CultureExplorerTypeDescriptor : ICustomTypeDescriptor
	{
		public AttributeCollection GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this, true);
		}

		public string GetClassName()
		{
			return TypeDescriptor.GetClassName(this,true);
		}

		public string GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this, true);
		}

		public abstract TypeConverter GetConverter();

		public EventDescriptor GetDefaultEvent()
		{
			return null;
		}

		public PropertyDescriptor GetDefaultProperty()
		{
			return null;
		}

		public object GetEditor(Type editorBaseType)
		{
			return TypeDescriptor.GetEditor(this, editorBaseType, true);
		}

		public EventDescriptorCollection GetEvents()
		{
			return new EventDescriptorCollection(new EventDescriptor[0]);
		}

		public EventDescriptorCollection GetEvents(Attribute[] attributes)
		{
			return new EventDescriptorCollection(new EventDescriptor[0]);
		}

		public PropertyDescriptorCollection GetProperties()
		{
			return GetProperties(null);
		}

		public abstract PropertyDescriptorCollection GetProperties(Attribute[] attributes);

		public object GetPropertyOwner(PropertyDescriptor pd)
		{
			return this;
		}
	}
	
	class CalendarTypeDescriptor : CultureExplorerTypeDescriptor
	{
		public override TypeConverter GetConverter()
		{
			return new CalendarTypeConverter();
		}

		public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			return new PropertyDescriptorCollection(
				new PropertyDescriptor[]
				{
					new ReadOnlyPropertyDescriptor<Calendar>("AlgorithmType", null)
					, new ReadOnlyPropertyDescriptor<Calendar>("Eras", null)
					, new ReadOnlyPropertyDescriptor<Calendar>("MaxSupportedDateTime", null)
					, new ReadOnlyPropertyDescriptor<Calendar>("MinSupportedDateTime", null)
					, new ReadOnlyPropertyDescriptor<Calendar>("TwoDigitYearMax", null)
				}
			);
		}
	}

	class CompareInfoTypeDescriptor : CultureExplorerTypeDescriptor
	{
		public override TypeConverter GetConverter()
		{
			return new CompareExplorerTypeConverter();
		}

		public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			return new PropertyDescriptorCollection(
				new PropertyDescriptor[]
				{
					new ReadOnlyPropertyDescriptor<CompareInfo>("LCID", null)
					, new ReadOnlyPropertyDescriptor<CompareInfo>("Name", null)
				}
			);
		}
	}

	class DateTimeFormatInfoTypeDescriptor : CultureExplorerTypeDescriptor
	{
		public override TypeConverter GetConverter()
		{
			return new DateTimeFormatExplorerTypeConverter();
		}

		public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			return new PropertyDescriptorCollection(
				new PropertyDescriptor[]
				{
					new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("AMDesignator", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("AbbreviatedDayNames", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("AbbreviatedMonthGenitiveNames", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("AbbreviatedMonthNames", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("Calendar", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("CalendarWeekRule", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("DateSeparator", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("DayNames", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("FirstDayOfWeek", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("FullDateTimePattern", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("LongDatePattern", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("LongTimePattern", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("MonthDayPattern", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("MonthGenitiveNames", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("MonthNames", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("NativeCalendarName", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("PMDesignator", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("RFC1123Pattern", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("ShortDatePattern", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("ShortTimePattern", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("ShortestDayNames", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("SortableDateTimePattern", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("TimeSeparator", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("UniversalSortableDateTimePattern", null)
					, new ReadOnlyPropertyDescriptor<DateTimeFormatInfo>("YearMonthPattern", null)
				}
			);
		}
	}

	class NumberFormatInfoTypeDescriptor : CultureExplorerTypeDescriptor
	{
		public override TypeConverter GetConverter()
		{
			return new NumberFormatExplorerTypeConverter();
		}

		public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			return new PropertyDescriptorCollection(
				new PropertyDescriptor[]
				{
					new ReadOnlyPropertyDescriptor<NumberFormatInfo>("CurrencyDecimalDigits", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("CurrencyDecimalSeparator", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("CurrencyGroupSeparator", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("CurrencyGroupSizes", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("CurrencyNegativePattern", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("CurrencyPositivePattern", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("CurrencySymbol", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("DigitSubstitution", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("NaNSymbol", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("NativeDigits", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("NegativeInfinitySymbol", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("NegativeSign", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("NumberDecimalDigits", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("NumberDecimalSeparator", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("NumberGroupSeparator", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("NumberGroupSizes", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("NumberNegativePattern", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("PercentDecimalDigits", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("PercentDecimalSeparator", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("PercentGroupSeparator", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("PercentGroupSizes", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("PercentNegativePattern", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("PercentPositivePattern", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("PercentSymbol", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("PerMilleSymbol", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("PositiveInfinitySymbol", null)
					, new ReadOnlyPropertyDescriptor<NumberFormatInfo>("PositiveSign", null)
				}
			);
		}
	}

	class TextInfoTypeDescriptor : CultureExplorerTypeDescriptor
	{
		public override TypeConverter GetConverter()
		{
			return new TextExplorerTypeConverter();
		}

		public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			return new PropertyDescriptorCollection(
				new PropertyDescriptor[]
				{
					new ReadOnlyPropertyDescriptor<TextInfo>("ANSICodePage", null)
					, new ReadOnlyPropertyDescriptor<TextInfo>("CultureName", null)
					, new ReadOnlyPropertyDescriptor<TextInfo>("EBCDICCodePage", null)
					, new ReadOnlyPropertyDescriptor<TextInfo>("IsRightToLeft", null)
					, new ReadOnlyPropertyDescriptor<TextInfo>("LCID", null)
					, new ReadOnlyPropertyDescriptor<TextInfo>("ListSeparator", null)
					, new ReadOnlyPropertyDescriptor<TextInfo>("MacCodePage", null)
					, new ReadOnlyPropertyDescriptor<TextInfo>("OEMCodePage", null)
				}
			);
		}
	}
}
