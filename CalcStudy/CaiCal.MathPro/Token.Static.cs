using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaiCal.MathPro
{
    public partial class Token
    {
        public static int GetTokenPriority(TokenType type, string token)
        {
            int priority = -1;
            switch (type)
            {
                case TokenType.Operator:
                    {
                        if ("+-".Contains(token[0]))
                            priority = 1;
                        else if ("*/".Contains(token[0]))
                            priority = 2;
                        else if ("^".Contains(token[0]))
                            priority = 3;
                        else
                            throw new NotImplementedException($"{token}");
                    }
                    break;
                case TokenType.Function:
                    {
                        priority = 4;
                    }
                    break;
                case TokenType.Operand:
                case TokenType.LeftBracket:
                case TokenType.RightBracket:
                    {
                        priority = -1;
                    }
                    break;
                default: throw new ArgumentException($"token type = {token.ToString()}???");
            }
            return priority;
        }

        public static TokenType GetTokenType(char token)
        {
            if (token.IsDigit())
            {
                if (token == '.') throw new ArgumentException("<.>不能独立作为操作数");
                return TokenType.Operand;
            }else if (token.IsOperator())
            {
                return TokenType.Operator;
            }else if (token.IsLeftBracket())
            {
                return TokenType.LeftBracket;
            }else if (token.IsRightBracket())
            {
                return TokenType.RightBracket;
            }
            else
            {
                throw new ArgumentException($"{token}是不合适的TokenType");
            }

        }

        public static TokenType GetTokenType(string token)
        {
            if (token == null)
                throw new ArgumentNullException($"token = {token} ？？？");
            if (token.Length == 1)
            {
                return GetTokenType(token[0]);
            }
            else
            {
                if(double.TryParse(token,out double d))
                {
                    return TokenType.Operand;
                }
                else
                {
                    return TokenType.Function;
                }
            }
        }

        public override string ToString()
        {
            return NormalizeString;
        }

        public static List<Token> Tokenize(string inp)
        {
            var ret = new List<Token>();
            string str = inp.RemoveSpace();
            int i = 0;
            int cnt = str.Length;
            StringBuilder token = new StringBuilder();
            char c;

            while (i < cnt)
            {
                c = str[i];
                token = new StringBuilder(c.ToString());
                if (c.IsDigit())
                {
                    while (i + 1 < cnt && str[i + 1].IsDigit())
                    {
                        token.Append(str[i + 1]);
                        i += 1;
                    }
                }else if (c.IsLetter())
                {
                    while (i + 1 < cnt && str[i + 1].IsLetter())
                    {
                        token.Append(str[i + 1]);
                        i += 1;
                    }
                }else if (c.IsOperator())
                {
                    if (c == '-' && (i == 0 || i > 0 && str[i - 1].IsLeftBracket()))
                    {
                        while(i + 1 < cnt && str[i + 1].IsDigit())
                        {
                            token.Append(str[i + 1]);
                            i += 1;
                        }
                    }
                }else if (c.IsLeftBracket() || c.IsRightBracket())
                {

                }
                else
                {
                    throw new ArgumentException($"token={c.ToString()}???");
                }

                i += 1;
                ret.Add(new Token(token.ToString()));
            }

            return ret;
        }
    }
}
