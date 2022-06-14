using System;
namespace Course.Task8
{
    class DairyProducts : Product, IEquatable<DairyProducts>
    {
        private int expirationDate;

        public int ExpirationDate { get => expirationDate; set => expirationDate = value; }

        public DairyProducts() : base()
        {
            ExpirationDate = default;
        }

        public DairyProducts(string name, float price, int weight, int expirationDate) : base(name, price, weight)
        {
            if (expirationDate <= 0) throw new ArgumentException("Термiн придатностi меньше 1");
            ExpirationDate = expirationDate;
        }

        public override void ChangePrice(float percent)
        {
            percent += expirationDate / 100;
            base.ChangePrice(percent);
        }

        public bool Equals(DairyProducts obj)
        {
            return Name == obj.Name &&Price == obj.Price && Weight == obj.Weight
                 && ExpirationDate == obj.ExpirationDate;
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
            return base.GetHashCode() + ExpirationDate.GetHashCode();
        }
    }
}
