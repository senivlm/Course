using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task9
{
    class Dish : IEnumerable
    {
        public string name { get; }
        public Dictionary<Ingridient, float> ingridients { get; }

        public Dish(string name)
        {
            this.name = name;
            ingridients = new Dictionary<Ingridient, float>();
        }

        public Dish(string name, Dictionary<Ingridient, float> ingridients)
        {
            this.name = name;
            this.ingridients = ingridients;
        }

        public void AddIngridient(string line, Dictionary<string, Ingridient> ingridients)
        {
            if (string.IsNullOrWhiteSpace(line)) return;

            var ingridientString = line.Split(',');
            float weight = 0;
            try
            {
                if (ingridientString.Length != 2) throw new ArgumentException($"Incorrect line {line}");
                if (!ingridients.ContainsKey(ingridientString[0])) throw new KeyNotFoundException(ingridientString[0]);
                if (!float.TryParse(ingridientString[1], out weight)) throw new ArgumentException($"Incorrect weight in line {line}");
                this.ingridients.Add(ingridients[ingridientString[0]], weight);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(KeyNotFoundException e) 
            {
                float price = UserInterface.GetFloatFromConsole($"Iнгрiдiєнт {e.Message} не знайдено. Введiть цiну iнгрiдiєнту за кiлограм у гривнях", 2);
                if (price == 0) return;
                else
                {
                    ingridients.Add(e.Message, new Ingridient(e.Message, price));
                    FileInteract.WriteToFile(@"../../../Task9/Prices.txt", $"\n{e.Message}-{price}");
                    AddIngridient(line, ingridients);
                }
            }
        }

        public void AddIngridient(Ingridient ingridient, float weight)
        {
            try
            {
                if (ingridients.ContainsKey(ingridient)) throw new ArgumentException($"Ingridient {ingridient} exist");
                ingridients.Add(ingridient, weight);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Dish dish) return dish.name == this.name;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, ingridients);
        }

        public IEnumerator GetEnumerator()
        {
            return ingridients.GetEnumerator();
        }
    }
}
