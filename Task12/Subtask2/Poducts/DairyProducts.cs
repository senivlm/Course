using System;
namespace Course.Task12.Subtask2
{
    class DairyProducts : Product
    {
        public DairyProducts(string name, float price, int weight, DateTime expirationDate) : base(name, price, weight, expirationDate)
        {
        }

        public DairyProducts(string info) : base(info)
        {
        }

        public override void ChangePrice(float percent)
        {
            percent += (expirationDate - DateTime.Today).Days / 100;
            base.ChangePrice(percent);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DairyProducts)) return false;
            return (this.Name == ((DairyProducts)obj).Name && this.Price == ((DairyProducts)obj).Price && this.Weight == ((DairyProducts)obj).Weight
                 && this.ExpirationDate.Equals(((DairyProducts)obj).ExpirationDate));
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
