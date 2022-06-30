using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task12
{
    class Calculator
    {
        private static Stack<string> exit;

        private static void TransformFunc(string func)
        {
            exit = new();
            Stack<char> stack = new();
            int startOfNumber = 0;
            bool isNewNumber = true;
            for (int i = 0; i < func.Length; i++)
            {
                if (!char.IsDigit(func[i]))
                {
                    if (char.IsWhiteSpace(func[i]))
                    {
                        if (isNewNumber)
                        {
                            exit.Push(func[startOfNumber..i]);
                            isNewNumber = false;
                        }
                    }
                    else if (func[i] == ')')
                    {
                        exit.Push(func[startOfNumber..i]);
                        isNewNumber = false;

                        while (stack.Peek() != '(')
                        {
                            exit.Push(stack.Pop().ToString());
                        }
                        stack.Pop();

                        if (char.IsLetter(stack.Peek())) AddOperationFromStackToExit(stack);
                    }
                    else
                    {
                        if (func[i] == '*' || func[i] == '/')
                            if (stack?.Peek() == '/' || stack?.Peek() == '*')
                                exit.Push(stack.Pop().ToString());
                        stack.Push(func[i]);
                    }
                }
                else
                {
                    startOfNumber = i;
                    isNewNumber = true;
                    if (i + 1 == func.Length)
                    {
                        exit.Push(func[startOfNumber..(i + 1)]);
                    }
                }
            }

            while (stack.Count > 0)
            {
                exit.Push(stack.Pop().ToString());
            }

            exit = Reverse();
        }

        public static double Calculate(string func)
        {
            TransformFunc(func);
            return CalculateFunc();
        }

        private static Stack<string> Reverse()
        {
            Stack<string> result = new();
            while(exit.Count > 0)
                result.Push(exit.Pop());

            return result;
        }

        private static double CalculateFunc()
        {
            Stack<double> temp = new();
            while (exit.Count > 0)
            {
                if (char.IsDigit(exit.Peek()[0])) temp.Push(double.Parse(exit.Pop()));
                else DoOperation(temp);
            }

            return temp.Pop();
        }
        
        private static void DoOperation(Stack<double> stack)
        {
            double temp = 0;
            switch (exit.Pop())
            {
                case "-":
                    temp = stack.Pop();
                    stack.Push(stack.Pop() - temp);
                    break;
                case "+":
                    stack.Push(stack.Pop() + stack.Pop());
                    break;
                case "/":
                    temp = stack.Pop();
                    stack.Push(stack.Pop() / temp);
                    break;
                case "*":
                    stack.Push(stack.Pop() * stack.Pop());
                    break;
                case "^":
                    temp = stack.Pop();
                    stack.Push(Math.Pow(temp, stack.Pop()));
                    break;
                case "cos":
                    stack.Push(Math.Cos(stack.Pop()));
                    break;
                case "sin":
                    stack.Push(Math.Sin(stack.Pop()));
                    break;
                case "tg":
                    stack.Push(Math.Tan(stack.Pop()));
                    break;
                case "ctg":
                    stack.Push(1 / Math.Tan(stack.Pop()));
                    break;
                default:
                    break;
            }
        }

        private static void AddOperationFromStackToExit(Stack<char> stack)
        {
            string res = "";
            while (char.IsLetter(stack.Peek()))
            {
                res += stack.Pop();
            }
            exit.Push(new string(res.Reverse().ToArray()));
        }
    }
}
