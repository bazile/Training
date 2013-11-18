using System;
using System.Collections.Generic;
using System.Globalization;

namespace FormatView
{
    public class FormatResult<T> where T : IFormattable 
    {
        public FormatResult(T val, string formatString) : this(val, formatString, CultureInfo.CurrentCulture)
        {
        }

        public FormatResult(T val, string formatString, IFormatProvider formatProvider)
        {
            FormatString = formatString;
            Result = val.ToString(formatString, formatProvider);
        }

        public string FormatString { get; private set; }
        public string Result { get; private set; }
        public string Comment { get; set; }
    }


    public class FormatStringInfo
    {
        public string[] Formats { get; set; }
        public string Name { get; set; }
    }

    public interface IFormatStrings<T>
    {
        List<FormatStringInfo> GetFormatString();
    }

    public class FormatStrings : IFormatStrings<DateTime>, IFormatStrings<int>
    {
        private FormatStrings() { }

        private static readonly FormatStrings _fs = new FormatStrings();

        public static List<FormatStringInfo> GetFormatString<T>()
        {
            return ((IFormatStrings<T>) _fs).GetFormatString();
        }

        List<FormatStringInfo> IFormatStrings<DateTime>.GetFormatString()
        {
            //"f" Full date/time pattern (short time).
            //"F" Full date/time pattern (long time).
            //"g" General date/time pattern (short time).
            //"G" General date/time pattern (long time).
            //"M", "m" Month/day pattern.
            //"O", "o" Round-trip date/time pattern.
            //"R", "r" RFC1123 pattern.
            //"s" Sortable date/time pattern.
            //"t" Short time pattern.
            //"T" Long time pattern.
            //"u" Universal sortable date/time pattern.
            //"U" Universal full date/time pattern.
            //"Y", "y" Year month pattern.
            return new List<FormatStringInfo>
                {
                    new FormatStringInfo{ Name = "Short date pattern"                    , Formats = new[] {"d"} },
                    new FormatStringInfo{ Name = "Long date pattern"                     , Formats = new[] {"D"} },
                    new FormatStringInfo{ Name = "Full date/time pattern (short time)"   , Formats = new []{"f"} },
                    new FormatStringInfo{ Name = "Full date/time pattern (long time)"    , Formats = new []{"F"} },
                    new FormatStringInfo{ Name = "General date/time pattern (short time)", Formats = new []{"g"} },
                    new FormatStringInfo{ Name = "General date/time pattern (long time)" , Formats = new []{"G"} },
                    new FormatStringInfo{ Name = "Month/day pattern"                     , Formats = new []{"M", "m"} },
                    new FormatStringInfo{ Name = "Round-trip date/time pattern"          , Formats = new []{"O", "o"} },
                    new FormatStringInfo{ Name = "RFC1123 pattern"                       , Formats = new []{"R", "r"} },
                    new FormatStringInfo{ Name = "Sortable date/time pattern"            , Formats = new []{"s"} },
                    new FormatStringInfo{ Name = "Short time pattern"                    , Formats = new []{"t"} },
                    new FormatStringInfo{ Name = "Long time pattern"                     , Formats = new []{"T"} },
                    new FormatStringInfo{ Name = "Universal sortable date/time pattern"  , Formats = new []{"u"} },
                    new FormatStringInfo{ Name = "Universal full date/time pattern"      , Formats = new []{"U"} },
                    new FormatStringInfo{ Name = "Year month pattern"                    , Formats = new []{"Y", "y"} },
                };
        }

        List<FormatStringInfo> IFormatStrings<int>.GetFormatString()
        {
            return new List<FormatStringInfo>
                {
                    new FormatStringInfo{ Name = "Currency", Formats = new[] {"C", "c"}},
                    new FormatStringInfo{ Name = "Decimal" , Formats = new[] {"D", "d"}},
                };
        }
    }
}
