using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14.Subtask2
{
    [Serializable]
    public class AbstractFoodProduct : AbstractProduct, IFoodProduct
    {
        private DateTime expirationDate;
        private double weight;

        public AbstractFoodProduct(string name, double price, DateTime expirationDate, double weight) : base(name, price)
        {
            ExpirationDate = expirationDate;
            Weight = weight;
        }

        public DateTime ExpirationDate { get => expirationDate; private set => expirationDate = value; }
        public double Weight { get => weight; private set => weight = value; }

        public override void ChangePrice(int percent)
        {
            percent += (expirationDate - DateTime.Today).Days / 100;
            base.ChangePrice(percent);
        }

        public override bool Equals(object obj)
        {
            if (obj is AbstractFoodProduct foodProduct)
            {
                return foodProduct.Weight == Weight && base.Equals(obj);
            }
            return false;
        }

        public override string ToString()
        {
            return base.ToString() + $" | ExpirationDate - {expirationDate} | Weight - {weight}";
        }
    }
}