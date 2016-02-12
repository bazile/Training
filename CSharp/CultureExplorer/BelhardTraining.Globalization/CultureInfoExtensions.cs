using System.Globalization;

namespace BelhardTraining.Globalization
{
    public static class CultureInfoExtensions
    {
        public static LanguageInfo GetLanguageInfo(this CultureInfo culture)
        {
            return LanguageInfo.GetLanguageInfo(culture);
        }
    }
}
