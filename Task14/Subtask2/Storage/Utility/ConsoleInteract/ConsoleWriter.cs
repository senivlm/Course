using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14.Subtask2
{
    class ConsoleWriter
    {
        public static void WriteListOnConsole<T>(List<T> listOfItems)
        {
            foreach (T item in listOfItems)
                Console.WriteLine(item.ToString());
        }

        public static void WriteOnConsole<T>(T message)
        {
            Console.WriteLine(message.ToString());
        }
    }
}
