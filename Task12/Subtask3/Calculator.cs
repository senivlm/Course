using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task12
{
    class Calculator
    {// чому така структура використана для поля. Є проблеми з проектуванням. Розкажу.
        private static Stack<string> exit;

        private static void TransformFunc(string func)
        {
            exit = new();
            //Операції не обов'язково є одним символом. Краще одразу припустити, що це може бути стрічка
            Stack<char> stack = new();
            int startOfNumber = 0;
            bool isNewNumber = true;

            FileInteract.WriteToFile("../../../Task12/Subtask3/Result.txt", "Польський запис :\n\n");

            int j = 1;

            for (int i = 0; i < func.Length; i++)
            {
                string number = $"Step {j} : ";
                if (!char.IsDigit(func[i]))
                {
                    if (char.IsWhiteSpace(func[i]))
                    {
                        if (isNewNumber)
                        {
                            FileInteract.WriteToFile("../../../Task12/Subtask3/Result.txt", number + func[startOfNumber..i] + "\n");
                            j++;
                            exit.Push(func[startOfNumber..i]);
                            isNewNumber = false;
                        }
                    }
                    else if (func[i] == ')')
                    {
                        //result += func[startOfNumber..i] + " ";
                        //exit.Push(func[startOfNumber..i]);
                        //isNewNumber = false;

                        while (stack.Peek() != '(')
                        {
                            FileInteract.WriteToFile("../../../Task12/Subtask3/Result.txt", number + stack.Peek() + "\n");
                            j++;
                            exit.Push(stack.Pop().ToString());
                        }
                        stack.Pop();

                        if (char.IsLetter(stack.Peek())) AddOperationFromStackToExit(stack);
                    }
                    else
                    {
                        if (func[i] == '*' || func[i] == '/')
                            if (stack?.Peek() == '/' || stack?.Peek() == '*')
                            {
                                FileInteract.WriteToFile("../../../Task12/Subtask3/Result.txt", number + stack.Peek() + "\n");
                                j++;
                                exit.Push(stack.Pop().ToString());
                            }
                        stack.Push(func[i]);
                    }
                }
                else
                {
                    if (!isNewNumber)
                    {
                        startOfNumber = i;
                        isNewNumber = true;
                        if (i + 1 == func.Length)
                        {
                            FileInteract.WriteToFile("../../../Task12/Subtask3/Result.txt", number + func[startOfNumber..(i + 1)] + "\n");
                            j++;
                            exit.Push(func[startOfNumber..(i + 1)]);
                        }
                    }
                }
            }

            while (stack.Count > 0)
            {
                string number = $"Step {j} : ";
                FileInteract.WriteToFile("../../../Task12/Subtask3/Result.txt", number + stack.Peek() + "\n");
                j++;
                exit.Push(stack.Pop().ToString());
            }

            exit = Reverse();
        }

        public static double Calculate(string func)
        {
            TransformFunc(func);

            FileInteract.WriteToFile("../../../Task12/Subtask3/Result.txt", "\nОбчислення\n\n");

            return CalculateFunc();
        }

        private static Stack<string> Reverse()
        {
            Stack<string> result = new();
            while (exit.Count > 0)
                result.Push(exit.Pop());

            return result;
        }

        private static double CalculateFunc()
        {
            int j = 1;
            Stack<double> temp = new();
            while (exit.Count > 0)
            {
                string number = $"Step {j} : ";
                if (char.IsDigit(exit.Peek()[0]))
                {
                    temp.Push(double.Parse(exit.Pop()));
                    FileInteract.WriteToFile("../../../Task12/Subtask3/Result.txt", number + temp.Peek() + "\n");
                }
                else
                {
                    FileInteract.WriteToFile("../../../Task12/Subtask3/Result.txt", number + exit.Peek() + "\n");
                    DoOperation(temp);
                    FileInteract.WriteToFile("../../../Task12/Subtask3/Result.txt", "Exit : " + temp.Peek() + "\n");
                }
                j++;
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
                    stack.Push(Math.Pow(stack.Pop(), temp));
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
