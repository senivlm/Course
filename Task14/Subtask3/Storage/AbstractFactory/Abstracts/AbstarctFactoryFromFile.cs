using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task14
{
    internal abstract class AbstarctFactoryFromFile : IAbstractFactory
    {
        protected readonly string pathToFirstFile;
        protected readonly string pathToSecondFile;

        protected int FirstFileLineCount;
        protected int SecondFileLineCount;
        protected int FirstCount;
        protected int SecondCount;

        public AbstarctFactoryFromFile(string pathToFirstFile, string pathToSecondFile)
        {
            this.pathToFirstFile = pathToFirstFile;
            this.pathToSecondFile = pathToSecondFile;

            FirstFileLineCount = FileReader.GetLineCount(pathToFirstFile);
            SecondFileLineCount = FileReader.GetLineCount(pathToSecondFile);
            FirstCount = 0;
            SecondCount = 0;
        }

        public abstract IProduct CreateProductA();

        public abstract IProduct CreateProductB();
    }
}
