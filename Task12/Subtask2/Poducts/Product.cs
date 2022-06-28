using System;

namespace Course.Task12.Subtask2
{
    abstract class Product
    {
        protected string name;
        protected float price;
        protected int weight;
        protected DateTime expirationDate;

        public string Name { get => name; set => name = value; }
        public float Price { get => price; set => price = value; }
        public int Weight { get => weight; set => weight = value; }
        public DateTime ExpirationDate { get => expirationDate; set => expirationDate = value; }

        public Product(string name, float price, int weight, DateTime expirationDate)
        {
            if (price < 1 || weight < 1) throw new ArgumentException("цiна або вага меньше 1");
            Name = name;
            Price = price;
            Weight = weight;
            ExpirationDate = expirationDate;
        }

        public Product(string info)
        {
            var splitedLine = info.Split();
            string exeptions = "";
            int weight;
            int price;
            DateTime expirationDate;

            //To upper case first letter
            if (splitedLine[0][0] != char.ToUpper(splitedLine[0][0])) splitedLine[0] = char.ToUpper(splitedLine[0][0]) + splitedLine[0].Substring(1);

            if (!int.TryParse(splitedLine[1], out price)) exeptions += "Incorect price, ";
            if (!int.TryParse(splitedLine[2], out weight)) exeptions += "Incorect weight, ";
            if (price < 1 || weight < 1) exeptions += "Incorect price or weight, ";
            if (!DateTime.TryParse(splitedLine[3], out expirationDate)) throw new ArgumentException("Incorect expirationDate, ");
            if (exeptions.Length != 0) throw new ArgumentException(exeptions);
            Name = splitedLine[0];
            Price = price;
            Weight = weight;
            ExpirationDate = expirationDate;
        }

        public virtual void ChangePrice(float percent) => Price -= Price * (percent / 100);

        public override bool Equals(object obj)
        {
            if (!(obj is Product)) return false;
            return (this.Name == ((Product)obj).Name && this.Price == ((Product)obj).Price && this.Weight == ((Product)obj).Weight);
        }

        public override string ToString()
        {
            return $"Name: {Name}\tPrice: {Price}\tWeight: {Weight}\tExpirationDate {ExpirationDate}";
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
