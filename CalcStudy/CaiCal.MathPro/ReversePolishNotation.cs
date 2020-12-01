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
                    case TokenType.Function://如果是函数，直接压入堆栈
                        LoggerManager.WriteDebug($"stack.Push({token})");
                        stack.Push(token);
                        break;
                    case TokenType.Operand://如果是操作数，加入队列尾部
                        LoggerManager.WriteDebug($"queue.Enqueue({token})");
                        queue.Enqueue(token);
                        break;
                    case TokenType.LeftBracket://左括号直接压入堆栈
                        LoggerManager.WriteDebug($"stack.Push({token})");
                        stack.Push(token);
                        break;
                    case TokenType.RightBracket:
                        bool notFindLeftBracket = true;
                        do
                        {
                            Token last = stack.Pop();//依次弹出栈顶Token，直到遇到左括号
                            LoggerManager.WriteDebug($"stack.Pop() > {last}");
                            if (last.Type == TokenType.LeftBracket)
                            {
                                if (stack.Count == 0)
                                {
                                    notFindLeftBracket = false;
                                    break;
                                }
                                else
                                {
                                    last = stack.Pop();
                                    LoggerManager.WriteDebug($"stack.Pop() > {last}");
                                    if (last.Type == TokenType.Function)
                                    {
                                        queue.Enqueue(last);
                                        LoggerManager.WriteDebug($"queue.Enqueeu({last})");
                                    }
                                    else
                                    {
                                        stack.Push(last);
                                        LoggerManager.WriteDebug($"stack.Push({last})");
                                    }
                                    notFindLeftBracket = false;
                                    break;
                                }
                            }
                            queue.Enqueue(last);
                            LoggerManager.WriteDebug($"queue.Enqueue({last})");
                        } while (notFindLeftBracket);
                        break;
                    default:
                        break;
                }
            }
            );
            LoggerManager.WriteInfor($"Convert to Post Fix Ok ...");
            var list = queue.ToList();
            StringBuilder builder = new StringBuilder();
            list.ForEach(token => builder.Append(token.ToString() + ' '));
            LoggerManager.WriteInfor($"Post Fix > {builder.ToString()}");

            return queue;
        }

        public static double EvaluatePostFix(Queue<Token> postFix)
        {
            LoggerManager.WriteInfor("");
            LoggerManager.WriteInfor("");
            LoggerManager.WriteInfor("");
            LoggerManager.WriteInfor("Begin to Evaluate Post Fix ... ");
            Stack<Token> stack = new Stack<Token>();

            while (postFix.Count > 0)
            {
                Token last = postFix.Dequeue();
                LoggerManager.WriteDebug($"postFix.Dequeue() > {last}");
                if (last.Type == TokenType.Operand)
                {
                    stack.Push(last);
                    LoggerManager.WriteDebug($"stack.Push({last})");
                }
                else
                {
                    if (last.Type == TokenType.Operator)
                    {
                        var right = stack.Pop();
                        LoggerManager.WriteDebug($"stack.Pop() > {right}");
                        var left = stack.Pop();
                        LoggerManager.WriteDebug($"stack.Pop() > {left}");
                        LoggerManager.WriteDebug($"Calculating > {left} {last} {right}");
                        var temp = CalculateOpr(left, right, last);
                        LoggerManager.WriteDebug($"Calculated > {left} {last} {right} = {temp}");
                        stack.Push(new Token(temp.ToString()));
                    }else if (last.Type == TokenType.Function)
                    {
                        var fun = stack.Pop();
                        LoggerManager.WriteDebug($"stack.Pop() > {fun}");
                        LoggerManager.WriteDebug($"Calculating > {last}{fun}");
                        var temp = CalculateFunc(last, fun);
                        LoggerManager.WriteDebug($"Calculated > {last}{fun}");
                        stack.Push(new Token(temp.ToString()));
                    }
                }
                
            }
            LoggerManager.WriteInfor($"Finish Evaluating Post Fix ...");
            if(double.TryParse(stack.Pop().ToString(),out double res))
            {
                LoggerManager.WriteInfor($"Result={res}");
                return res;
            }
            else
            {
                throw new Exception("计算错误");
            }

        }

        private static Token CalculateOpr(Token left,Token right,Token opr)
        {
            if (left.Type != TokenType.Operand || right.Type != TokenType.Operand || opr.Type != TokenType.Operator)
                throw new ArgumentException($"Operating: {left} {opr} {right}???");
            return new Token(CalculateOpr(left.NormalizeString, right.NormalizeString, opr.NormalizeString).ToString());
        }

        private static Token CalculateFunc(Token fun,Token d)
        {
            if (fun.Type != TokenType.Function || d.Type != TokenType.Operand)
                throw new ArgumentException($"Function: {fun} {d}???");
            return new Token(CalculateFunc(fun.NormalizeString, d.NormalizeString).ToString());
        }
    }
}
