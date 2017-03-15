using System.Globalization;

namespace TrainingCenter.Globalization
{
    public static class CultureInfoExtensions
    {
        public static LanguageInfo GetLanguageInfo(this CultureInfo culture)
        {
            return LanguageInfo.GetLanguageInfo(culture);
        }
    }
}
