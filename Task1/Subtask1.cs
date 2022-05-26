using System;

namespace Course.Task1
{
    class Product
    {
        private string name;
        private int price;
        private int weight;

        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public int Weight { get => weight; set => weight = value; }

        public Product()
        {
        }

        public Product(string name, int price, int weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Product)) return false;
            return (this.Name == ((Product)obj).Name && this.Price == ((Product)obj).Price && this.Weight == ((Product)obj).Weight);
        }

        public override string ToString()
        {
            return $"Name: {Name}\tPrice: {Price}\tWeight: {Weight}";
        }
    }
}
