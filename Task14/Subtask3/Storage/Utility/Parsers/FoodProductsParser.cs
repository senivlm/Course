using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14
{
    static class FoodProductsParser
    {
        public static Meat ParseMeat(string line)
        {
            var splitedLine = line.Split(", ");
            if (splitedLine.Length != 6) throw new ArgumentOutOfRangeException();

            double price, weight;
            DateTime expirationTime;

            if (!TryParseFoodProduct(splitedLine[1..4], out price, out expirationTime, out weight)) throw new ArgumentException();

            MeatCategory category;
            MeatSort sort;

            if (!Enum.IsDefined(typeof(MeatCategory), splitedLine[4])) throw new ArgumentException("IncorrectCategory");
            else category = (MeatCategory)Enum.Parse(typeof(MeatCategory), splitedLine[4]);

            if (!Enum.IsDefined(typeof(MeatSort), splitedLine[5])) throw new ArgumentException("IncorrectSort");
            else sort = (MeatSort)Enum.Parse(typeof(MeatSort), splitedLine[5]);

            return new Meat(splitedLine[0], price, expirationTime, weight, category, sort);
        }

        public static DairyProduct ParseDairyProduct(string line)
        {
            var splitedLine = line.Split(", ");
            if (splitedLine.Length != 4) throw new ArgumentOutOfRangeException();

            double price, weight;
            DateTime expirationTime;

            if (!TryParseFoodProduct(splitedLine[1..4], out price, out expirationTime, out weight)) throw new ArgumentException();

            return new DairyProduct(splitedLine[0], price, expirationTime, weight);
        }

        public static AbstractFoodProduct ParseUnknownFoodProduct(string line)
        {
            string productType = line.Split()[0];
            
            switch (productType)
            {
                case "Meat":
                    return ParseMeat(line[(productType.Length + 1)..]);
                case "DairyProduct":
                    return ParseDairyProduct(line[(productType.Length + 1)..]);
                default:
                    return null;
            }
        }

        private static bool TryParseFoodProduct(string[] splitedLine, out double price, out DateTime expirationTime, out double weight)
        {
            try
            {
                string errors = "";
                if (!double.TryParse(splitedLine[0], out price)) errors += "UncorrectPrice";
                if (!DateTime.TryParse(splitedLine[1], out expirationTime)) errors += "UncorrectExpirationTime";
                if (!double.TryParse(splitedLine[2], out weight)) errors += "UncorrectWeight";
                return true;
            }
            catch (ArgumentException e)
            {
                ConsoleWriter.WriteOnConsole(e);
                price = default;
                expirationTime = default;
                weight = default;
                return false;
            }
        }
    }
}