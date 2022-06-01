using System;
using System.Collections.Generic;

namespace Course.Task2
{
    class Storage
    {
        private List<Product> products;

        public Storage()
        {
            products = new List<Product>();
        }

        public Storage(params Product[] products)
        {
            this.products = new List<Product>();
            this.products.AddRange(products ?? null);
        }

        public void AddInDialog()
        {
            UserInterface.AddProductsToStorage(this);
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void ChangePrice(int percent)
        {
            foreach(Product i in products)
            {
                i.ChangePrice(percent);
            }
        }

        public Product this[int index]
        {
            get
            {
                if (index >= 0 && index < products.Count)
                {
                    return products[index];
                }
                throw new ArgumentOutOfRangeException();
            }

            set
            {
                if (index >= 0 && index < products.Count)
                {
                    products[index] = value;
                }
                throw new ArgumentOutOfRangeException();
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine(this);
        }

        public List<Meat> GetMeats()
        {
            List<Meat> result = new List<Meat>();
            foreach(Product i in products)
            {
                if (i.GetType() == typeof(Meat)) result.Add((Meat)i);
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            foreach(Product i in products)
            {
                result += i + "\n";
            }
            return result;
        }
    }
}
