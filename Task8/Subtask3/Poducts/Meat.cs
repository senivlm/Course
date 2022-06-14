using System;
namespace Course.Task8 
{
    enum Category 
    { 
        Category1,
        Category2
    }

    enum Sort 
    {
        Mutton,
        Veal,
        Chicken,
        Pork
    }

    class Meat : Product, IEquatable<Meat>
    {
        Category category;
        Sort sort;

        internal Category Category { get => category; set => category = value; }
        internal Sort Sort { get => sort; set => sort = value; }
        
        public Meat() : base()
        {
            category = default;
            sort = default;
        }

        public Meat(string name, int price, int weight, Category category, Sort sort) : base(name, price, weight)
        {
            this.category = category;
            this.sort = sort;
        }

        public override void ChangePrice(float percent)
        {
            switch (category)
            {
                case Category.Category1:
                    percent += 5;
                    break;
                case Category.Category2:
                    percent += 10;
                    break;
            }

            base.ChangePrice(percent);
        }

        public bool Equals(Meat obj)
        {
            return Name == obj.Name && Price == obj.Price && Weight == obj.Weight
                 && category == obj.category && sort == obj.sort;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Meat)) return false;
            return (this.Name == ((Meat)obj).Name && this.Price == ((Meat)obj).Price && this.Weight == ((Meat)obj).Weight
                 && this.category == ((Meat)obj).category && this.sort == ((Meat)obj).sort);
        }

        public override string ToString()
        {
            string result = "";
            result += base.ToString() + $"\tCategory: {category}\tSort: {sort}";
            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + (Sort, Category).GetHashCode();
        }
    }
}