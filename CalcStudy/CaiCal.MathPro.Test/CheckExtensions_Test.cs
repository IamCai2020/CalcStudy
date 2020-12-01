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

        [TestMethod]
        public void Tokenize()
        {
            string str = "-2.3*4+ (-2-cos7)";
            var tokens = Token.Tokenize(str);
            Assert.AreEqual(10, tokens.Count);

            Assert.AreEqual(TokenType.Operand, tokens[0].Type);
            Assert.AreEqual("-2.3", tokens[0].NormalizeString);

            Assert.AreEqual(TokenType.Operator, tokens[1].Type);
            Assert.AreEqual("*", tokens[1].NormalizeString);

            Assert.AreEqual(TokenType.Operand, tokens[2].Type);
            Assert.AreEqual("4", tokens[2].NormalizeString);

            Assert.AreEqual(TokenType.Operator, tokens[3].Type);
            Assert.AreEqual("+", tokens[3].NormalizeString);

            Assert.AreEqual(TokenType.LeftBracket, tokens[4].Type);
            Assert.AreEqual("(", tokens[4].NormalizeString);

            Assert.AreEqual(TokenType.Operand, tokens[5].Type);
            Assert.AreEqual("-2", tokens[5].NormalizeString);

            Assert.AreEqual(TokenType.Operator, tokens[6].Type);
            Assert.AreEqual("-", tokens[6].NormalizeString);

            Assert.AreEqual(TokenType.Function, tokens[7].Type);
            Assert.AreEqual("cos", tokens[7].NormalizeString);

            Assert.AreEqual(TokenType.Operand, tokens[8].Type);
            Assert.AreEqual("7", tokens[8].NormalizeString);

            Assert.AreEqual(TokenType.RightBracket, tokens[9].Type);
            Assert.AreEqual(")", tokens[9].NormalizeString);
        }
    }
}
