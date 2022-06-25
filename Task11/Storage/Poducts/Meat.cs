using System;
namespace Course.Task11
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

    class Meat : Product
    {
        Category category;
        Sort sort;

        internal Category Category { get => category; set => category = value; }
        internal Sort Sort { get => sort; set => sort = value; }

        public Meat(string name, int price, int weight, Category category, Sort sort) : base(name, price, weight)
        {
            this.category = category;
            this.sort = sort;
        }

        public Meat(string info) : base(info)
        {
            var splitedLine = info.Split();
            string exeptions = "";

            //To upper case first letter
            if (splitedLine[3][0] != char.ToUpper(splitedLine[3][0])) splitedLine[3] = char.ToUpper(splitedLine[3][0]) + splitedLine[3].Substring(1);
            if (splitedLine[4][0] != char.ToUpper(splitedLine[4][0])) splitedLine[4] = char.ToUpper(splitedLine[4][0]) + splitedLine[4].Substring(1);

            //String to enum
            if (!Enum.IsDefined(typeof(Category), splitedLine[3])) exeptions += "Incorect category, ";
            else Category = (Category)Enum.Parse(typeof(Category), splitedLine[3]);
            if (!Enum.IsDefined(typeof(Sort), splitedLine[4])) exeptions += "Incorect sort, ";
            else Sort = (Sort)Enum.Parse(typeof(Sort), splitedLine[4]);

            //Create product or throw exception if one of arguments incorect
            if (exeptions.Length != 0) throw new ArgumentException(exeptions);
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
            throw new NotImplementedException();
        }
    }
}
