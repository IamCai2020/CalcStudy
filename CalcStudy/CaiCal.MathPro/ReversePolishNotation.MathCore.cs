using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaiCal.MathPro
{
    public partial class ReversePolishNotation
    {
        private static double CalculateOpr(string left, string right, string opr) =>
            CalculateOpr(Convert.ToDouble(left), Convert.ToDouble(right), opr);

        private static double CalculateOpr(double left, double right, string opr)
        {
            switch (opr)
            {
                case "+":return left + right;
                case "-":return left - right;
                case "*":return left * right;
                case "/":return left / right;
                case "^":return Math.Pow(left,right);
                
                default: throw new NotImplementedException($"{opr}???");
            }
        }

        private static double CalculateFunc(string func, string d) =>
            CalculateFunc(func, Convert.ToDouble(d));


        const double Deg2Rad = Math.PI / 180.0;
        private static double CalculateFunc(string func, double d)
        {
            switch (func)
            {
                case "cos": return Math.Cos(d * Deg2Rad);
                case "sin": return Math.Sin(d * Deg2Rad);
                case "sqr": return d*d;
                case "sqrt": return Math.Sin(d);
                default:throw new NotImplementedException(func);

            }
        }
    }
}
