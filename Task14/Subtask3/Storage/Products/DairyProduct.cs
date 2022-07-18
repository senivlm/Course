using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14
{
    class DairyProduct : AbstractFoodProduct
    {
        public DairyProduct(string name, double price, DateTime expirationDate, double weight) : base(name, price, expirationDate, weight)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj is DairyProduct) return true;
            return false;
        }
    }
}