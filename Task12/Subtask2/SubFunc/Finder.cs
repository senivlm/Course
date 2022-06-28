using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task12.Subtask2
{
    class Finder
    {
        public static void FindByName(string name, ref List<Product> result)
        {
            result = new(result.FindAll(x => x.Name == name));
        }

        public static void FindByPrice(float price, ref List<Product> result)
        {
            result = new(result.FindAll(x => x.Price == price));
        }

        public static void FindByWeight(int weight, ref List<Product> result)
        {
            result = new(result.FindAll(x => x.Weight == weight));
        }

        public static void FindByExpirationDate(DateTime expirationDate, ref List<Product> result)
        {
            result = new(result.FindAll(x => x.ExpirationDate.Equals(expirationDate)));
        }
    }
}
