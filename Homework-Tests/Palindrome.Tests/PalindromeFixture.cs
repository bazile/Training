using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Palindrome.Tests
{
    [TestFixture]
    public class PalindromeFixture
    {
        [Test, TestCaseSource("StringIsPalindromeData")]
        public bool StringIsPalindrome(string s)
        {
            return Palindrome.IsPalindrome(s);
        }

        public IEnumerable<TestCaseData> StringIsPalindromeData
        {
            get
            {
                string[] palindromes = {
                    "й",
                    "wЙW",
                    "А роза упала на лапу Азора",
                    "Аргентина манит негра",
                    "На в лоб, болван",
                    "Saippuakivikauppias",
                    "Sum summus mus",
                    "Madam, I’m Adam"
                };
                return palindromes.Select(str => new TestCaseData(str).Returns(true));
            }
        }
    }
}
