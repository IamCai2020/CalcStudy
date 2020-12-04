using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaiCal.MathSimple;

namespace StringExtensions_Test
{
    [TestClass]
    public class StringExtensions_Test
    {
        [TestMethod]
        public void IsOperator()
        {
            Assert.IsTrue("+".IsOperator());
        }

        [TestMethod]
        public void IsFunction()
        {
            Assert.IsTrue("Sin".IsFunction());
            Assert.IsFalse("-".IsFunction());
        }

        [TestMethod]
        public void IsOperand()
        {
            Assert.IsTrue("556688.9".IsOperand());
        }
    }
}
