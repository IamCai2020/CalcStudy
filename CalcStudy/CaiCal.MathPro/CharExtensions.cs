using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaiCal.MathPro
{
    public static class CharExtensions
    {
        public static bool IsDigit(this char self) => ".0123456789".Contains(self);

        public static bool IsOperator(this char self) => "+-*/^".Contains(self);

        public static bool IsLetter(this char self) => ('a' <= self && self <= 'z') || ('A' <= self && self <= 'Z');

        public static bool IsLeftBracket(this char self) => self == '(';

        public static bool IsRightBracket(this char self) => self == ')';

    }
}
