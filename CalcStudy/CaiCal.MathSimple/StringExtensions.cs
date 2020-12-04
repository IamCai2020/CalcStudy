using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaiCal.MathSimple
{
    public static class StringExtensions
    {
        public static bool IsOperator(this string self) => "+-*/^".Contains(self);

        public static bool IsFunction(this string self) => !Double.TryParse(self, out double d)&&!self.IsOperator();
         
        public static bool IsOperand(this string self) => Double.TryParse(self, out double d);
    }
}
