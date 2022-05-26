using System;

namespace Course.Task1
{
    class Buy
    {
        private Product[] products;

        public Buy(params Product[] products)
        {
            this.products = products != null ? products : null;
        }

        public int GetNumberOfProducts()
        {
            return products.Length;
        }

        public int GetPrice()
        {
            int result = 0;
            foreach(Product i in products)
            {
                result += i.Price;
            }
            return result;
        }

        public int GetWeight()
        {
            int result = 0;
            foreach (Product i in products)
            {
                result += i.Weight;
            }
            return result;
        }

        public Product this[int index]
        {
            get
            {
                if (index > products.Length && index < 0)
                    throw new ArgumentOutOfRangeException();
                return products[index];
            }
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
