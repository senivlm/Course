using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task13
{
    class PersonGenerator
    {
        public Random rand = new();
        private string filePathToStatuses = "../../../Task13/Files/SomeValues/Statuses.txt";
        private string filePathToNames = "../../../Task13/Files/SomeValues/Names.txt";
        private string filePathToPersons = "../../../Task13/Files/Persons.txt";

        public PersonGenerator(string filePathToStatuses, string filePathToNames, string filePathToPersons)
        {
            this.filePathToStatuses = filePathToStatuses;
            this.filePathToNames = filePathToNames;
            this.filePathToPersons = filePathToPersons;
        }

        public PersonGenerator()
        {
        }

        public void GenerateAndWritePersonsToFile(int counter)
        {
            for(int i = 0; i < counter; i++)
            {
                GenerateAndWritePersonToFile();
            }
        }

        public void GenerateAndWritePersonToFile()
        {
            int age = rand.Next(10, 100);
            Statuses status = (Statuses)Enum.Parse(typeof(Statuses), FileReader.GetLineByCounter(filePathToStatuses, rand.Next(0, 3)));
            if (status == Statuses.Normal && age >= 60) status = Statuses.Pensioner;

            FileWriter.WriteToFile(filePathToPersons, $"{status} {FileReader.GetLineByCounter(filePathToNames, rand.Next(0, 8))} {age} {Math.Round(rand.NextDouble(), 2)} {rand.Next(3, 10)}\n");
        }

        public Person GetPersonFromFile(int personNumber)
        {
            try
            {
                return PersonParse.Parse(FileReader.GetLineByCounter(filePathToPersons, personNumber));
            }
            catch (ArgumentException e)
            {
                UserInterface.WriteOnConsole(e.Message);
            }
            return new Person();
        }
    }
}