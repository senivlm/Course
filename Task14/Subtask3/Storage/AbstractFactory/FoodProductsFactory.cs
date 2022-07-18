using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14
{
    class FoodProductsFactory : AbstarctFactoryFromFile
    {
        /// <param name="pathToFirstFile">Path to file whith dairy products</param>
        /// <param name="pathToSecondFile">Path to file whith meat</param>
        public FoodProductsFactory(string pathToFirstFile, string pathToSecondFile) : base(pathToFirstFile, pathToSecondFile)
        {
        }

        public override IProduct CreateProductA()
        {
            FirstCount++;
            if (FirstCount >= FirstFileLineCount) FirstCount = 0;

            return FoodProductsParser.ParseDairyProduct(FileReader.GetLineByCounter(pathToFirstFile, FirstCount));
        }

        public override IProduct CreateProductB()
        {
            SecondCount++;
            if (SecondCount >= SecondFileLineCount) SecondCount = 0;

            return FoodProductsParser.ParseMeat(FileReader.GetLineByCounter(pathToSecondFile, SecondCount));
        }
    }
}
