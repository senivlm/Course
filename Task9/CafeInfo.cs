using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task9
{
    class CafeInfo
    {
        public Dictionary<string, Ingridient> ingridients { get; }
        private readonly string pathToCurrencyFile = @"../../../Task9/Course.txt";
        private float dollar, euro;
        public Menu menu { get; }

        public CafeInfo(string priceFile, string dishesFile)
        {
            dollar = 0;
            euro = 0;
            var stringList = FileInteract.ReadFromFile(priceFile);
            ingridients = new Dictionary<string, Ingridient>();
            foreach (string line in stringList)
                AddIngridient(line);

            SetCourse();
            stringList = FileInteract.ReadFromFile(dishesFile);
            menu = new Menu(stringList, ingridients);
        }

        public void AddIngridient(string line)
        {
            try
            {
                ingridients.Add(line.Split('-')[0], new Ingridient(line));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AddIngridient(string name, float price)
        {
            ingridients.Add(name, new Ingridient(name, price));
        }

        private void SetCourse()
        {
            List<string> courseString = FileInteract.ReadFromFile(pathToCurrencyFile);
            foreach (string i in courseString)
            {
                try
                {
                    var str = i.Split('-');
                    if (str.Length != 2) throw new ArgumentException($"Incorrect line {i}");

                    if (!Enum.IsDefined(typeof(Currency), str[0])) throw new ArgumentException($"Incorrect currency name in line {i}");
                    Currency currency = (Currency)Enum.Parse(typeof(Currency), str[0]);

                    switch (currency)
                    {
                        case Currency.Dollar:
                            if (!float.TryParse(str[1], out dollar)) throw new ArgumentException($"Incorrect value in line {i}");
                            break;
                        case Currency.Euro:
                            if (!float.TryParse(str[1], out euro)) throw new ArgumentException($"Incorrect value in line {i}");
                            break;
                        default:
                            break;
                    }
                }catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public float GetPriceOfIngridients(Currency currency)
        {
            float result = 0;
            foreach(KeyValuePair<Dish, float> ingridient in menu)
                result += ingridient.Value;

            switch (currency)
            {
                case Currency.Dollar:
                    result *= dollar;
                    break;
                case Currency.Euro:
                    result *= euro;
                    break;
                default:
                    break;
            }
            return result;
        }

        public Dictionary<string, float> GetWeightOfIngridients()
        {
            Dictionary<string, float> result = new Dictionary<string, float>();

            foreach(KeyValuePair<Dish, float> dish in menu)
            {
                foreach(KeyValuePair<Ingridient, float> ingridient in dish.Key)
                {
                    if (result.ContainsKey(ingridient.Key.name)) result.Add(ingridient.Key.name, result[ingridient.Key.name] + ingridient.Value);
                    else result.Add(ingridient.Key.name, ingridient.Value);
                }
            }

            return result;
        }

        public void WriteInfoToFile(string filePath, Currency currency)
        {
            StringBuilder result = new StringBuilder();
            var weightOfIngridients = GetWeightOfIngridients();
            foreach(var pair in weightOfIngridients)
            {
                result.Append($"{pair.Key} - {pair.Value} gramm\n");
            }
            result.Append($"Total price - {GetPriceOfIngridients(currency)}");

            FileInteract.WriteToFile(filePath, result.ToString());
        }
    }
}