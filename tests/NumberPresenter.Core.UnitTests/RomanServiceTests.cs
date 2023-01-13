using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberPresenter.Core.UnitTests
{
    [TestClass]
    public class RomanServiceTests
    {
        [DataTestMethod]
        [DataRow(49, "XLIX")]
        [DataRow(426, "CDXXVI")]
        [DataRow(2000, "MM")]
        [DataRow(606, "DCVI")]
        [DataRow(1, "I")]
        public void NumericToRoman_Int_Tests(int numeric, string numeral)
        {
            var subject = GetSubject();

            var result = subject.NumericToRoman(numeric);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(numeral, result.Result);
        }

        [DataTestMethod]
        [DataRow("49", "XLIX")]
        [DataRow("426", "CDXXVI")]
        [DataRow("2000", "MM")]
        [DataRow("606", "DCVI")]
        [DataRow("1", "I")]
        [DataRow("5", "V")]
        [DataRow("10", "X")]
        [DataRow("50", "L")]
        [DataRow("100", "C")]
        [DataRow("500", "D")]
        [DataRow("1000", "M")]
        public void NumericToRoman_String_Tests(string numeric, string numeral)
        {
            var subject = GetSubject();

            var result = subject.NumericToRoman(numeric);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(numeral, result.Result);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow("  ")]
        public void NumericToRoman_String_NoStringReturnsError(string numeric)
        {
            var subject = GetSubject();

            var result = subject.NumericToRoman(numeric);

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Please enter a value", result.ErrorMessage);
        }

        [DataTestMethod]
        [DataRow("onetwothree")]
        [DataRow("123hello")]
        public void NumericToRoman_String_NonNumberReturnsError(string numeric)
        {
            var subject = GetSubject();

            var result = subject.NumericToRoman(numeric);

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Please enter a valid number", result.ErrorMessage);
        }

        private RomanService GetSubject()
        {
            return new RomanService();
        }
    }
}
