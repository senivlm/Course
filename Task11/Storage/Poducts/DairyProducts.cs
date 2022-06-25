using System;
namespace Course.Task11
{
    class DairyProducts : Product
    {
        private int expirationDate;

        public int ExpirationDate { get => expirationDate; set => expirationDate = value; }

        public DairyProducts(string name, float price, int weight, int expirationDate) : base(name, price, weight)
        {
            if (expirationDate <= 0) throw new ArgumentException("Термiн придатностi меньше 1");
            ExpirationDate = expirationDate;
        }

        public DairyProducts(string info) : base(info)
        {
            var splitedLine = info.Split();
            string exeptions = "";
            int expirationDate = 0;
            if (!int.TryParse(splitedLine[3], out expirationDate)) exeptions += "Incorect expirationDate, ";
            if (exeptions.Length != 0) throw new ArgumentException(exeptions);
            this.expirationDate = expirationDate;
        }

        public override void ChangePrice(float percent)
        {
            percent += expirationDate / 100;
            base.ChangePrice(percent);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DairyProducts)) return false;
            return (this.Name == ((DairyProducts)obj).Name && this.Price == ((DairyProducts)obj).Price && this.Weight == ((DairyProducts)obj).Weight
                 && this.ExpirationDate == ((DairyProducts)obj).ExpirationDate);
        }

        public override string ToString()
        {
            string result = "";
            result += base.ToString() + $"\tExpiration Date: {ExpirationDate}";
            return result;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
