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
                    while (!(OP = opStack.Pop()).Equals('(')) //пока не встретим (
                    {
                        //применим оператор OP к двум последним элементам на стеке
                        useOp(OP);
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
                default:
                    throw new Exception("in get Priority wrong input");
            }
        }

        private void useOp(char op)
        {
            switch (op)
            {
                case '+':
                    numStack.Push(numStack.Pop() + numStack.Pop());
                    break;
                case '-':
                    numStack.Push(-numStack.Pop() + numStack.Pop());
                    break;
                case '*':
                    numStack.Push(numStack.Pop() * numStack.Pop());
                    break;
                case '/':
                    Int64 a = numStack.Pop();
                    Int64 b = numStack.Pop();
                    numStack.Push(b / a);
                    break;
                case '(': //skip (, может произойти если пользователь забыл закрывающие скобки 
                    break;
            }
        }

        public void addNum(Int64 num)
        {
            numStack.Push(num);
        }

        public Int64 getTop()
        {
            if (numStack.Count == 0 || opStack.Count != 0 && opStack.Peek().Equals('('))
            {
                return 0;
            }
            else
            {
                return numStack.Peek();
            }
        }

        public void changeTopOp(char op)
        {
            while (opStack.Peek().Equals('('))
            {
                opStack.Pop();
            }
            opStack.Pop();
            opStack.Push(op);
        }

        public void popTopOp()
        {
            opStack.Pop();
        }

        public void calculate()
        {
            while (opStack.Count != 0)
            {
                useOp(opStack.Pop());
            }
        }

        public void clear()
        {
            numStack.Clear();
            opStack.Clear();
        }

        public char[] getOps()
        {
            return opStack.ToArray();
        }

        public Int64[] getNums()
        {
            return numStack.ToArray();
        }

        private Stack<Int64> numStack = new Stack<Int64>();
        private Stack<char> opStack = new Stack<char>();
    }
}
