using System.Globalization;
using NUnit.Framework;

namespace TrainingCenter.Globalization.Tests
{
    [TestFixture]
    public class LanguageInfoFixture
    {
        [Test]
        public void GetLanguageInfo_ReturnsNonNull_ForAllCultures()
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (var culture in cultures)
            {
                LanguageInfo langInfo = culture.GetLanguageInfo();
                Assert.IsNotNull(langInfo, string.Format("LanguageInfo is 'null' for culture {0}", culture.DisplayName));
            }
        }

        [Test]
        public void Name_IsNotNull_ForAllCultures()
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (var culture in cultures)
            {
                LanguageInfo langInfo = culture.GetLanguageInfo();
                Assert.IsNotNull(langInfo.Name, string.Format("Name is 'null' for culture {0}", culture.DisplayName));
            }
        }

        [Test]
        public void GetLanguageInfo_ReturnsEmpty_ForInvariantCulture()
        {
            LanguageInfo langInfo = CultureInfo.InvariantCulture.GetLanguageInfo();
            Assert.AreEqual("", langInfo.Name);
            Assert.AreEqual("", langInfo.TwoLetterIsoCode);
            Assert.AreEqual("", langInfo.ThreeLetterIsoCode);
            Assert.AreEqual(LanguageFamily.NotSpecified, langInfo.Family);
            Assert.AreEqual(LanguageType.NotSpecified, langInfo.Type);
        }
    }
}
