using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaiCal.MathPro;

namespace CaiCal.MathPro.Test
{
    [TestClass]
    public class CheckExtensions_Test
    {
        [TestMethod]
        public void IsOperator()
        {
            Assert.IsTrue('+'.IsOperator());
            Assert.IsTrue('-'.IsOperator());
            Assert.IsTrue('*'.IsOperator());
            Assert.IsTrue('/'.IsOperator());

        }

        [TestMethod]
        public void IsDigit()
        {
            Assert.IsTrue('.'.IsDigit());
            Assert.IsTrue('0'.IsDigit());
            Assert.IsTrue('9'.IsDigit());
        }

        [TestMethod]
        public void IsLetter()
        {
            Assert.IsTrue('A'.IsLetter());
            Assert.IsTrue('a'.IsLetter());
            Assert.IsTrue('Z'.IsLetter());
            Assert.IsTrue('z'.IsLetter());
        }

        [TestMethod]
        public void IsBracket()
        {
            Assert.IsTrue('('.IsLeftBracket());
            Assert.IsTrue(')'.IsRightBracket());
        }
    }
}
