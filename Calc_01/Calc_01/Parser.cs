using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calc_01
{
    class Parser
    {
        public void addOp(char op)
        {
            if (op.Equals('('))
            {
                opStack.Push(op);
            }
            else
                if (op.Equals(')'))
                {
                    char OP;
                    try
                    {
                        while (!(OP = opStack.Pop()).Equals('(')) //пока не встретим (
                        {
                            //применим оператор OP к двум последним элементам на стеке
                            useOp(OP);
                        }
                    }
                    catch (InvalidOperationException e)
                    {
                        throw new Exception("скобки не согласованы");
                    }
                }
                else //op \in {+,-,*,\}
                {
                    //приоритет предыдущего оператора
                    while (opStack.Count != 0 && getPriority(opStack.Peek()) >= getPriority(op))
                    {
                        char OP = opStack.Pop(); //снимаем предыдущие операторы
                        useOp(OP); //применяем их
                    }
                    //добавляем новый
                    opStack.Push(op);
                }
        }

        private int getPriority(char op)
        {
            switch (op)
            {
                case '(':
                    return 0;
                case '+': case '-': 
                    return 1;
                case '*': case '/': 
                    return 2;
                case UNARY_MINUS:
                    return 3;
                default:
                    throw new Exception("in get Priority wrong input");
            }
        }

        private void useOp(char op)
        {
            try
            {
                switch (op)
                {
                    case '+':
                        numStack.Push(numStack.Pop() + numStack.Pop());
                        break;
                    case '-':
                        numStack.Push(-numStack.Pop() + numStack.Pop());
                        break;
                    case UNARY_MINUS:
                        numStack.Push(-numStack.Pop());
                        break;
                    case '*':
                        numStack.Push(numStack.Pop() * numStack.Pop());
                        break;
                    case '/':
                        Int64 a = numStack.Pop();
                        Int64 b = numStack.Pop();
                        numStack.Push(b / a);
                        break;
                    default:
                        throw new Exception("несогласованные скобки");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Syntax error");
            }

        }

        public void addNum(Int64 num)
        {
            numStack.Push(num);
        }

        
        public Int64 evaluate(string expr)
        {
            parseExpr(expr);
            while (opStack.Count > 0)
            {
                useOp(opStack.Pop());
            }
            if (numStack.Count > 1)
            {
                throw new Exception("syntax error");
            }
            return numStack.Peek();
            //return Converter.from10to8(numStack.Peek());
        }

        private void parseExpr(string expr)
        {
            int pos = 0;
            int len = expr.Length;
            char prevOp = '(';
            bool prevIsOp = true;
            while (pos < len) //пока есть символы
            {
                string token = readToken(expr, pos);
                //token = оператор или число
                
                if (isNumber(token))
                {
                    addNum(Convert.ToInt64(token, 10));
                    prevIsOp = false;
                }
                else //operator
                {
                    if (prevIsOp && prevOp != ')')
                    {
                        //в этом случае унарный оператор (оператор после другого оператора)
                        //или скобки
                        char Op = Convert.ToChar(token);
                        if (Op == '-')
                        {
                            addOp(UNARY_MINUS);
                            prevOp = UNARY_MINUS;
                        } else if (Op == '*' || Op == '\\') //унарное деление и умножение под запретом
                        {
                            throw new Exception("неверный унарный оператор");
                        }
                        if (Op == '(' || Op == ')')
                        {
                            addOp(Op);
                            prevOp = Op;
                        }
                        prevIsOp = true;
                    }
                    else
                    {
                        prevOp = Convert.ToChar(token);
                        addOp(prevOp);
                        prevIsOp = true;
                    }
                }
                pos += token.Length;
            }
            if (prevIsOp && prevOp != ')')
            {
                throw new Exception("Syntax error");
            }
        }

        private bool isNumber(string token)
        {
            try
            {
                Convert.ToInt64(token);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        private string readToken(string expr, int pos)
        {
            if (isNumber(expr[pos].ToString()))
            {
                //считываем число
                int len = 1;
                while ((pos+len) < expr.Length && isNumber(expr[pos + len].ToString()))
                {
                    len++;
                }
                return expr.Substring(pos, len);
            }
            else //если оператор
            {
                return expr[pos].ToString();
            }
        }


        private Stack<Int64> numStack = new Stack<Int64>();
        private Stack<char> opStack = new Stack<char>();
        const char UNARY_MINUS = '#'; //отдельное обозначение для унарных операторов
    }
}
