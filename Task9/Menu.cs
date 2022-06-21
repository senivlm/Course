using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task9
{
    enum Currency
    {
        Dollar,
        Euro,
    }

    class Menu : IEnumerable
    {
        public Dictionary<Dish, float> dishes { get; }

        public Menu(params Dish[] dishes)
        {
            this.dishes = new Dictionary<Dish, float>();
            if (dishes == null)
            {
                return;
            }

            foreach(Dish dish in dishes)
            {
                AddDish(dish);
            }
        }

        public Menu(List<string> stringList, Dictionary<string, Ingridient> ingridients)
        {
            int k = 0;
            this.dishes = new Dictionary<Dish, float>();
            while (k < stringList.Count)
            {
                Dish dish = new Dish(stringList[k++]);
                while (true)
                {
                    if (k >= stringList.Count) break;
                    dish.AddIngridient(stringList[k], ingridients);
                    k++;
                }
                AddDish(dish);
            }
        }

        public void AddDish(Dish dish)
        {
            if (this.dishes.ContainsKey(dish)) return;

            float price = 0;
            foreach (KeyValuePair<Ingridient, float> ingridient in dish)
                price += ingridient.Key.price * (dish.ingridients[ingridient.Key] / 1000);

            this.dishes.Add(dish, price);
        }

        public IEnumerator GetEnumerator()
        {
            return dishes.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach(KeyValuePair<Dish, float> dish in dishes)
            {
                result.Append($"{dish.Key.name} - {dish.Value}");
            }

            return result.ToString();
        }
    }
}
