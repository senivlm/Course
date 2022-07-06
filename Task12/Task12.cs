using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task12
{
    class Task12
    {
        public static void Start()
        {
            //Menu a = new();
            Console.WriteLine(Calculator.Calculate("12 + 2 * ( ( 3 * 4 ) + ( 10 / 5 ) )"));
            Console.WriteLine(Calculator.Calculate("3 + 4 * 2 / ( 1 - 5 ) ^ 2"));
        }
    }
}