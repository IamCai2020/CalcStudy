using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaiCal.Contract;

namespace CaiCal.MathSimple
{
    public class ExpressionSimple:IExpression
    {
        public string Left { get; private set; } = "";
        public string Right { get; private set; } = "";
        public string Operator { get; private set; } = "";

        public string Push(string inp)
        {
            if (inp == "=")
            {
                if (Left != "" && Right != "")
                {
                    var tmp="";
                    switch (Operator)
                    {
                        case "+": tmp= (double.Parse(Left) + double.Parse(Right)).ToString(); break;
                        case "-": tmp= (double.Parse(Left) - double.Parse(Right)).ToString(); break;
                        case "*": tmp= (double.Parse(Left) * double.Parse(Right)).ToString(); break;
                        case "/": tmp= (double.Parse(Left) / double.Parse(Right)).ToString(); break;
                        default:  tmp = ""; break;
                    }
                    Left = "";
                    Right = "";
                    Operator = "";
                    return tmp;
                }
            }

            if (inp.IsOperator())
            {
                if (Left == "")
                {

                }
                else
                {
                    Operator = inp;
                }
            }
            else if (inp.IsOperand())
            {
                if (Operator != "")
                {
                    Right += inp;
                }
                else
                {
                    Left += inp;
                }
            }
            return Left + Operator + Right;
        }
    }
}
