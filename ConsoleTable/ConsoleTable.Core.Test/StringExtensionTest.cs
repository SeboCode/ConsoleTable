using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleTable.Core.Test
{
    [TestClass]
    public class StringExtensionsTest
    {
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
            Assert.IsTrue("  \t\t\n\n \t\n".IsEmptyOrWhiteSpace());
        }

        [TestMethod]
        public void Test_IsEmptyOrWhiteSpace_NonWhiteSpace()
        {
            Assert.IsFalse("This text is not white space.".IsEmptyOrWhiteSpace());
        }
    }
}
