using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task10
{
    class WordDoesntFoundExeption : Exception
    {
        public WordDoesntFoundExeption(string message) : base(message) { }
    }
}
