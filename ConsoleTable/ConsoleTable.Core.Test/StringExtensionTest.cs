using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleTable.Core.Test
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void Test_IsNullOrEmptyOrWhiteSpace_NullString()
        {
            Assert.IsTrue(((string)null).IsNullOrEmptyOrWhiteSpace());
        }

        [TestMethod]
        public void Test_IsNullOrEmptyOrWhiteSpace_EmptyString()
        {
            Assert.IsTrue(string.Empty.IsNullOrEmptyOrWhiteSpace());
        }

        [TestMethod]
        public void Test_IsNullOrEmptyOrWhiteSpace_WhiteSpace()
        {
            Assert.IsTrue("   ".IsNullOrEmptyOrWhiteSpace());
        }

        [TestMethod]
        public void Test_IsNullOrEmptyOrWhiteSpace_WhiteSpaceTabsAndWraps()
        {
            Assert.IsTrue("  \t\t\r\n\r\n \t\r\n".IsNullOrEmptyOrWhiteSpace());
        }

        [TestMethod]
        public void Test_IsNullOrEmptyOrWhiteSpace_NonWhiteSpace()
        {
            Assert.IsFalse("This text is not white space.".IsNullOrEmptyOrWhiteSpace());
        }

        [TestMethod]
        public void Test_IsEmptyOrWhiteSpace_NullString()
        {
            Assert.IsFalse(((string)null).IsEmptyOrWhiteSpace());
        }

        [TestMethod]
        public void Test_IsEmptyOrWhiteSpace_EmptyString()
        {
            Assert.IsTrue(string.Empty.IsEmptyOrWhiteSpace());
        }

        [TestMethod]
        public void Test_IsEmptyOrWhiteSpace_WhiteSpace()
        {
            Assert.IsTrue("   ".IsEmptyOrWhiteSpace());
        }

        [TestMethod]
        public void Test_IsEmptyOrWhiteSpace_WhiteSpaceTabsAndWraps()
        {
            Assert.IsTrue("  \t\t\r\n\r\n \t\r\n".IsEmptyOrWhiteSpace());
        }

        [TestMethod]
        public void Test_IsEmptyOrWhiteSpace_NonWhiteSpace()
        {
            Assert.IsFalse("This text is not white space.".IsEmptyOrWhiteSpace());
        }
    }
}
