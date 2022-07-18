using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14.Subtask2
{
    [Serializable]
    public class Meat : AbstractFoodProduct
    {
        private Category category;
        private Sort sort;

        public Category Category { get => category; }
        public Sort Sort { get => sort; }


        public Meat(string name, double price, DateTime expirationDate, double weight, Category category, Sort sort) : base(name, price, expirationDate, weight)
        {
            this.category = category;
            this.sort = sort;
        }

        public override void ChangePrice(int percent)
        {
            switch (category)
            {
                case Category.Prime:
                    percent += 15;
                    break;
                case Category.Medium:
                    percent += 10;
                    break;
                case Category.Low:
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
