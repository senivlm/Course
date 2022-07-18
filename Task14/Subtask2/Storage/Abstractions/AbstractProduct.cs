using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14.Subtask2
{
    [Serializable]
    public class AbstractProduct : IProduct
    {
        private string name;
        private double price;

        public AbstractProduct(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get => name; private set => name = value; }
        public double Price { get => price; private set => price = value; }

        public virtual void ChangePrice(int percent)
        {
            Price -= Price * (percent / 100);
        }

        public override bool Equals(object obj)
        {
            if (obj is AbstractProduct abstractProduct)
            {
                return Name.Equals(abstractProduct.Name) && Price == abstractProduct.Price;
            } 
            return false;
        }

        public override string ToString()
        {
            return $"Name - {name} | Price - {price}";
        }
    }
}
