using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task12
{
    static class UserInterface
    {
        private static string startOfMessage = "Введiть наступну iнформацiю: ";

        public static string[] GetSplitedStringFromConsole(int numberOfParts, string message)
        {
            string[] result;

            do
            {
                Console.WriteLine(startOfMessage + message);
                result = Console.ReadLine().Split();
            } while (result.Length != numberOfParts);

            return result;
        }

        public static string GetStringFromConsole(string message, int numberOfAttempts = 5)
        {
            string result = "";
            for (int i = 0; i < numberOfAttempts; i++)
            {
                Console.WriteLine(startOfMessage + message);
                result = Console.ReadLine();
                if (!string.IsNullOrEmpty(result)) break;
            }
            return result;
        }

        public static string GetFilePath()
        {
            while (true)
            {
                string result = "";
                Console.WriteLine("Якщо файл знаходиться у данiй папкi натиснiть 1, в iншому випадку 2, для виходу iншу цифру");
                int userInput = GetIntFromConsole("номер дiї");
                switch (userInput)
                {
                    case 1:
                        result = "../../../" + GetStringFromConsole("назву файлу");
                        break;
                    case 2:
                        result = GetStringFromConsole("шлях до файлу");
                        break;
                    default:
                        return result;
                }
                if (File.Exists(result))
                {
                    return result;
                }
            }
        }

        public static int GetIntFromConsole(string message)
        {
            int result = 0;
            do
            {
                Console.WriteLine(startOfMessage + message);
                if (int.TryParse(Console.ReadLine(), out result))
                    break;
            } while (true);

            return result;
        }

        public static float GetFloatFromConsole(string message, int numberOfAttempts)
        {
            float result = 0;
            for (int i = 0; i < numberOfAttempts; i++)
            {
                Console.Write(startOfMessage + message + " ");
                if (float.TryParse(Console.ReadLine(), out result))
                    break;
            }

            return result;
        }

        public static void WriteListStringOnConsole(List<string> list)
        {
            foreach(string line in list)
                Console.WriteLine(line);
        }

        public static void WriteOnConsole(string str)
        {
            Console.WriteLine(str);
        }
    }
}
