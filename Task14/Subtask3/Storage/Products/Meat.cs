using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14
{
    class Meat : AbstractFoodProduct
    {
        private MeatCategory category;
        private MeatSort sort;

        public MeatCategory Category { get => category; }
        public MeatSort Sort { get => sort; }


        public Meat(string name, double price, DateTime expirationDate, double weight, MeatCategory category, MeatSort sort) : base(name, price, expirationDate, weight)
        {
            this.category = category;
            this.sort = sort;
        }

        public override void ChangePrice(int percent)
        {
            switch (category)
            {
                case MeatCategory.Prime:
                    percent += 15;
                    break;
                case MeatCategory.Medium:
                    percent += 10;
                    break;
                case MeatCategory.Low:
                    percent += 5;
                    break;
                default:
                    break;
            }
            base.ChangePrice(percent);
        }

        public override bool Equals(object obj)
        {
            if (obj is Meat meat)
            {
                return meat.Category == Category && meat.Sort == Sort && base.Equals(obj);
            }
            return false;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Category - {category} | Sort - {sort}";
        }
    }
}
