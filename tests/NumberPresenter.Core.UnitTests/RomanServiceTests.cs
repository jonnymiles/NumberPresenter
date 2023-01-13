using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberPresenter.Core.UnitTests
{
    [TestClass]
    public class RomanServiceTests
    {
        [TestMethod]
        public void SmokeTest()
        {
            var subject = GetSubject();

            var result = subject.NumericToRoman(1234);
        }

        private RomanService GetSubject()
        {
            return new RomanService();
        }
    }
}
