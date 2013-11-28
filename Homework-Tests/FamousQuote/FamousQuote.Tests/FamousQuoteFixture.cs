using BelhardTraining.FamousQuote.Service;
using NUnit.Framework;

namespace FamousQuote.Tests
{
    [TestFixture]
    public class FamousQuoteFixture
    {
        private IFamousQuote _svc;

        [SetUp]
        public void TestSetUp()
        {
            _svc = new FamousQuoteService();
        }

        [Test]
        public void ReturnsNull()
        {
            string text = _svc.FindQuoteByAuthor("Марк Твен");
            Assert.IsNull(text);
        }

        public void ReturnsQuoteByAuthorName()
        {
            const string text = "Люк, я твой отец";
            const string author = "Дарт Вейдер";
            _svc.AddQuote(text, author);

            string text2 = _svc.FindQuoteByAuthor(author);
            Assert.AreEqual(text, text2);
        }
    }
}
