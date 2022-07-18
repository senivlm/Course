using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14
{
    internal class StationeryProductsFactory : AbstarctFactoryFromFile
    {
        /// <param name="pathToFirstFile">Path to file whith wipes</param>
        /// <param name="pathToSecondFile">Path to file whith notebooks</param>
        public StationeryProductsFactory(string pathToFirstFile, string pathToSecondFile) : base(pathToFirstFile, pathToSecondFile)
        {
        }

        public override IProduct CreateProductA()
        {
            FirstCount++;
            if (FirstCount >= FirstFileLineCount) FirstCount = 0;

            return StationeryProductsParser.ParseWipes(FileReader.GetLineByCounter(pathToFirstFile, FirstCount));
        }

        public override IProduct CreateProductB()
        {
            SecondCount++;
            if (SecondCount >= SecondFileLineCount) SecondCount = 0;

            return StationeryProductsParser.ParseNotebook(FileReader.GetLineByCounter(pathToSecondFile, SecondCount));
        }
    }
}
