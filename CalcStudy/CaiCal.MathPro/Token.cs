using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaiCal.MathPro
{
    public partial class Token
    {
        public TokenType Type { get; private set; }

        public string NormalizeString { get; private set; }

        public int Priority { get; private set; } = -1;

        public Token(string token)
        {
            this.NormalizeString = token.ToLower();
            this.Type = GetTokenType(this.NormalizeString);
            this.Priority = GetTokenPriority(this.Type,this.NormalizeString);
        }



    }
}
