using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaiCal.Contract
{
    public interface IExpression
    {
        string Push(string inp);
    }
}
