using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14
{
    interface IProduct
    {
        public string Name { get; }
        public double Price { get; }

        public void ChangePrice(int percent);
    }
}