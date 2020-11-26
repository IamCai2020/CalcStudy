using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaiCal.MathPro
{
    public static class StringExtensions
    {
        public static string RemoveSpace(this string self) => self.Replace(" ", string.Empty);
    }
}
