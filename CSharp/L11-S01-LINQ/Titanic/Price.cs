using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace TrainingCenter.LinqToObjectsDemo.Titanic
{
    public struct Price : IComparable<Price>, IEquatable<Price>, IFormattable
	{
		private int _totalPence;
		public int TotalPence
		{
			get { return _totalPence; }
			set { _totalPence = value; }
		}

		// Фунт, шиллинг, пенс
		// 1:20:240

		public int Pounds { get { return _totalPence / 240; } }
		public int Shillings { get { return (_totalPence - (_totalPence / 240) * 240) / 12; } }
		public int Pence { get { return (_totalPence - (_totalPence / 240) * 240) % 12; } }

		public Price(string text)
		{
			int pounds = 0;
			int shillings = 0;
			int pence = 0;

			string[] parts = Regex.Split(text, @"\s+");
			foreach (string p in parts)
			{
				if (p.StartsWith("£")) pounds = int.Parse(p.Substring(1), NumberStyles.None);
				else if (p.EndsWith("s")) shillings = ushort.Parse(p.TrimEnd('s'), NumberStyles.None);
				else if (p.EndsWith("d")) pence = ushort.Parse(p.TrimEnd('d'), NumberStyles.None);
			}

			_totalPence = pounds * 240 + shillings * 12 + pence;
		}

		private Price(int totalPence)
		{
			_totalPence = totalPence;
		}

		public static Price operator +(Price x, Price y)
		{
			return new Price(x._totalPence + y._totalPence);
		}

		public double ModernEquivalent
		{
			get
			{
				// http://inflation.stephenmorley.org/
				// http://www.sp12.hull.ac.uk/tools/table.htm
				const double inflation = 108.0;
				return Math.Round(inflation * _totalPence * 0.0042, 2);
			}
		}

        public static bool operator==(Price left, Price right)
        {
			return left._totalPence == right._totalPence;
        }

        public static bool operator !=(Price left, Price right)
        {
			return left._totalPence != right._totalPence;
		}

        public override bool Equals(object obj)
        {
			if (obj == null || !(obj is Price)) return false;
			return Equals((Price)obj);
        }

        public bool Equals(Price price)
        {
			return _totalPence == price._totalPence;
        }

        public override int GetHashCode()
        {
            unchecked
            {
				return 17 * 486187739 + _totalPence;
			}
        }

        public int CompareTo(Price price)
		{
			if (_totalPence < price._totalPence)
				return -1;
			if (_totalPence > price._totalPence)
				return 1;
			return 0;
		}

		public override string ToString()
		{
            return ToString(null, null);
		}

        public string ToString(string format)
        {
            return ToString(format, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "G";
            formatProvider = formatProvider ?? CultureInfo.CurrentCulture;

            switch (format)
            {
                case "G":
                    string price = "";
                    if (Pounds > 0) price += "£" + Pounds.ToString(formatProvider);
                    if (Shillings > 0) price += (price.Length > 0 ? " " : "") + Shillings.ToString(formatProvider) + "s";
                    if (Pence > 0) price += (price.Length > 0 ? " " : "") + Pence.ToString(formatProvider) + "d";

                    if (price.Length == 0) price = "0";

                    return price;

                case "M":
                    return ModernEquivalent.ToString("N2", formatProvider);
            }

            throw new FormatException(string.Format("Unsupported format '{0}'", format));
        }
    }
}
