using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14
{
    internal static class StationeryProductsParser
    {
        public static Notebook ParseNotebook(string line)
        {
            string errors = "";
            var splitedLine = line.Split(", ");
            if (splitedLine.Length != 4) errors += "IncorrectWipesInfoLenght";

            double price;
            int count;
            if (!TryParseStationeryProduct(splitedLine[1..3], out price, out count)) errors += "IncorrectWipesInfo";

            NotebookType notebookType = default;

            if(!Enum.IsDefined(typeof(NotebookType), splitedLine[3])) errors += "IncorrectNotebookType";
            else notebookType = (NotebookType)Enum.Parse(typeof(NotebookType), splitedLine[3]);

            if(errors.Length != 0) throw new ArgumentException(errors);
            return new Notebook(splitedLine[0], price, count, notebookType);
        }

        public static Wipes ParseWipes(string line)
        {
            string errors = "";
            var splitedLine = line.Split(", ");
            if (splitedLine.Length != 4) errors += "IncorrectWipesInfoLenght";

            double price;
            int count;

            if (!TryParseStationeryProduct(splitedLine[1..3], out price, out count)) errors += "IncorrectWipesInfo";

            WipesType wipesType = default;

            if (!Enum.IsDefined(typeof(WipesType), splitedLine[3])) errors += "IncorrectWipesType";
            else wipesType = (WipesType)Enum.Parse(typeof(WipesType), splitedLine[3]);

            if (errors.Length != 0) throw new ArgumentException(errors);

            return new Wipes(splitedLine[0], price, count, wipesType);
        }

        public static AbstractStationeryProduct ParseUncknownStationeryProduct(string line)
        {
            string productType = line.Split()[0];
            switch (productType)
            {
                case "Wipes":
                    return ParseWipes(line[(productType.Length + 1)..]);
                case "Notebook":
                    return ParseNotebook(line[(productType.Length + 1)..]);
                default:
                    return null;
            }
        }

        private static bool TryParseStationeryProduct(string[] splitedLine, out double price, out int count)
        {
            try
            {
                string errors = "";
                if (!double.TryParse(splitedLine[0], out price)) errors += "IncorrectPrice";
                if (!int.TryParse(splitedLine[1], out count)) errors += "IncorrectCount";
                if(errors.Length != 0) throw new ArgumentException(errors);
                return true;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                price = default;
                count = default;
                return false;
            }
        }
    }
}
