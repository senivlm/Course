using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14.Subtask2
{
    class UserConsoleInput
    {
        private static string startOfMessage = "Введiть наступну iнформацiю: ";
        private const int numberOfAttempts = 5;

        public static DateTime GetDateTimeFromConsole(string message, int numberOfAttempts = numberOfAttempts)
        {
            DateTime result = default;
            for (int i = 0; i < numberOfAttempts; i++)
            {
                Console.Write(startOfMessage + message + " ");
                var str = Console.ReadLine();
                if (DateTime.TryParse(str, out result)) break;
            }
            return result;
        }

        public static double GetDoubleFromConsole(string message, int numberOfAttempts = numberOfAttempts)
        {
            double result = 0;
            for (int i = 0; i < numberOfAttempts; i++)
            {
                Console.Write(startOfMessage + message + " ");
                if (double.TryParse(Console.ReadLine(), out result))
                    break;
            }

            return result;
        }

        public static string GetFilePath(string message, int numberOfAttempts = numberOfAttempts)
        {
            string result = "";
            for (int i = 0; i < numberOfAttempts; i++)
            {
                Console.WriteLine(startOfMessage + message);
                Console.WriteLine("Якщо файл знаходиться у даній папкі натисніть 1, в іншому випадку 2, для виходу іншу цифру");
                int userInput = GetIntFromConsole("номер дії");
                switch (userInput)
                {
                    case 1:
                        result = "../../../" + GetStringFromConsole("назву файлу");
                        break;
                    case 2:
                        result = GetStringFromConsole("шлях до файлу");
                        break;
                    default:
                        break;
                }
                if (File.Exists(result))
                {
                    return result;
                }
            }
            return null;
        }

        public static int GetIntFromConsole(string message, int numberOfAttempts = numberOfAttempts)
        {
            int result = 0;
            for (int i = 0; i < numberOfAttempts; i++)
            {
                Console.Write(startOfMessage + message + " ");
                if (int.TryParse(Console.ReadLine(), out result))
                    break;
            }
            return result;
        }

        public static string[] GetSplitedStringFromConsole(string message, int numberOfParts, int numberOfAttempts = numberOfAttempts)
        {
            string[] result;
            int i = 0;

            do
            {
                Console.Write(startOfMessage + message + " ");
                result = Console.ReadLine().Split();
                i++;
            } while (result.Length != numberOfParts || i == numberOfAttempts);

            return result;
        }

        public static string GetStringFromConsole(string message, int numberOfAttempts = numberOfAttempts)
        {
            string result = "";
            for (int i = 0; i < numberOfAttempts; i++)
            {
                Console.Write(startOfMessage + message + " ");
                result = Console.ReadLine();
                if (!string.IsNullOrEmpty(result)) break;
            }
            return result;
        }
    }
}
