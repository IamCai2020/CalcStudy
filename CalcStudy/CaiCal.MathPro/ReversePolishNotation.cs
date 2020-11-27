using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoongEgg.LoongLogger;
using LoongEgg.LoongCore;

namespace CaiCal.MathPro
{
    public static partial class ReversePolishNotation
    {
        /// <summary>
        /// 转换为后缀表达式
        /// </summary>
        /// <param name="tokens">中缀表达式的集合</param>
        /// <returns>逆波兰表达式的转换结果</returns>
         
        public static Queue<Token> ConvertToPostFix(List<Token> tokens)
        {
            LoggerManager.WriteInfor("开始转换后缀表达式……");
            // Stack of tokens with a type of 
            // TokenType.Function, TokenType.Operator or Bracket
            // [LAST IN FIRST OUT]
            Stack<Token> stack = new Stack<Token>();
            Queue<Token> queue = new Queue<Token>();
            stack.Push(new Token("("));
            tokens.Add(new Token(")"));

            tokens.ForEach(token =>
            {
                switch (token.Type)
                {
                    case TokenType.Operator:
                        if (stack.Count == 0)//如果栈为空
                        {
                            LoggerManager.WriteDebug($"stack.Push({token})");
                            stack.Push(token);//把操作符压入堆栈
                        }
                        else
                        {
                            Token last = stack.Pop();//把栈顶的操作符弹出，赋值给last
                            LoggerManager.WriteDebug($"stack.Pop()>{last}");
                            //如果last是左括号或者是右括号或者当前token的优先级大于等于栈顶token
                            if (last.Type == TokenType.LeftBracket || last.Type == TokenType.RightBracket || token.Priority >= last.Priority)
                            {
                                LoggerManager.WriteDebug($"stack.Push({last})");
                                stack.Push(last);//把last压回堆栈
                                LoggerManager.WriteDebug($"stack.Push({token})");
                                stack.Push(token);//把当前token压入堆栈

                            }
                            else//当前token优先级小于栈顶token优先级
                            {
                                do
                                {
                                    LoggerManager.WriteDebug($"queue.Enqueue({last})");
                                    queue.Enqueue(last);//上一个放到队列尾部

                                    last = stack.Pop();
                                    LoggerManager.WriteDebug($"stack.Pop()>{last}");
                                } while (token.Priority < last.Priority);
                                stack.Push(last);
                                LoggerManager.WriteDebug($"stack.Push({last})");
                                stack.Push(token);
                                LoggerManager.WriteDebug($"stack.Push({token})");
                            }
                        }
                        break;
                    case TokenType.Function:
                        break;
                    case TokenType.Operand:
                        break;
                    case TokenType.LeftBracket:
                        break;
                    case TokenType.RightBracket:
                        break;
                    default:
                        break;
                }
            }
            );

        }
    }
}
