using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task12
{
    class Task12
    {
        public delegate void a(object obj, out List<Subtask2.Product> b);

        public static void Start()
        {
            //Menu a = new();
            Course.Task12.Subtask2.Storage storage = new Subtask2.Storage(@"../../../Task12/Subtask2/Products.txt");
        }
    }
}