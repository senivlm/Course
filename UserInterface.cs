using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
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

        public static string GetStringFromConsole(string message)
        {
            Console.WriteLine(startOfMessage + message);
            return Console.ReadLine();
        }

        public static int GetIntFromConsole(string message)
        {
            int result = 0;
            do
            {
                Console.WriteLine(startOfMessage + message);
                if(int.TryParse(Console.ReadLine(), out result)) 
                    break;
            } while (true);

            return result;
        }

        public static void WriteOnConsole(string str)
        {
            Console.WriteLine(str);
        }
    }
}
