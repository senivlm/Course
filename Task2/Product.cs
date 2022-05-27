using System;

namespace Course.Task2
{
    class Product
    {
        protected string name;
        protected float price;
        protected int weight;

        public string Name { get => name; set => name = value; }
        public float Price { get => price; set => price = value; }
        public int Weight { get => weight; set => weight = value; }

        public Product()
        {
        }

        public Product(string name, float price, int weight)
        {
            if (price < 1 || weight < 1) throw new ArgumentException("цiна або вага меньше 1");
            Name = name;
            Price = price;
            Weight = weight;
        }

        public virtual void ChangePrice(float percent) => Price -= Price * (percent / 100);

        public override bool Equals(object obj)
        {
            if (!(obj is Product)) return false;
            return (this.Name == ((Product)obj).Name && this.Price == ((Product)obj).Price && this.Weight == ((Product)obj).Weight);
        }

        public override string ToString()
        {
            return $"Name: {Name}\tPrice: {Price}\tWeight: {Weight}";
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
