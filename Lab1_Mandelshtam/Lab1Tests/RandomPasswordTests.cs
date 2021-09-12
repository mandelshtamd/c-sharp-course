using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Lab1Tests
{
    [TestClass]
    public class RandomPasswordTests
    {
        [TestMethod]
        public void TwoDigitsTest()
        {
            var testPassword = RandomPassword.RandomPassword.GetRandomPassword();
            Assert.AreEqual(!Regex.IsMatch(testPassword, "(.*)\\d{2}(.*)"), true);
        }

        [TestMethod]
        public void CorrectLengthTest()
        {
            var testPassword = RandomPassword.RandomPassword.GetRandomPassword();
            var isCorrectLength = testPassword.Length >= 6 && testPassword.Length <= 20;
            Assert.AreEqual(isCorrectLength, true);
        }

        [TestMethod]
        public void ContainsUnderlineTest()
        {
            var testPassword = RandomPassword.RandomPassword.GetRandomPassword();
            var containsUnderline = testPassword.Contains("_");
            Assert.AreEqual(containsUnderline, true);
        }

        [TestMethod]
        public void CorrectUpperLettersNumberTest()
        {
            var testPassword = RandomPassword.RandomPassword.GetRandomPassword();
            var upperLettersCount = testPassword.Count(letter=> char.IsUpper(letter));
            Assert.AreEqual(upperLettersCount >= 2, true);
        }

        [TestMethod]
        public void CorrectNumbersCountTest()
        {
            var testPassword = RandomPassword.RandomPassword.GetRandomPassword();
            var upperLettersCount = testPassword.Count(c => char.IsNumber(c));
            Assert.AreEqual(upperLettersCount <= 5, true);
        }
    }
}