using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task13
{
    static class PersonParse
    {
        public static Person Parse(string line)
        {
            var splitedLine = line.Split();
            if (splitedLine.Length != 5) throw new ArgumentException();

            int age = 0;
            int timeServise = 0;
            double coordinates = 0;
            Statuses statuse = default;

            if (!int.TryParse(splitedLine[2], out age)) throw new ArgumentException();
            if (!int.TryParse(splitedLine[4], out timeServise)) throw new ArgumentException();
            if (!double.TryParse(splitedLine[3], out coordinates)) throw new ArgumentException();
            if (!Enum.IsDefined(typeof(Statuses), splitedLine[0])) throw new ArgumentException();
            else statuse = (Statuses)Enum.Parse(typeof(Statuses), splitedLine[0]);

            return new Person(statuse, splitedLine[1], age, coordinates, timeServise);
        }
    }
}
