using System;
using System.IO;

namespace Course.Task8
{
    class ClientInfo
    {
        public int apartmenNumber;
        public string surname;
        public int output;
        public int input;

        public ClientInfo()
        {
            apartmenNumber = default;
            surname = "";
            input = default;
            output = default;
        }

        public ClientInfo(string line)
        {
            string e = "";
            string[] str = line.Split();
            if (!int.TryParse(str[0], out apartmenNumber)) e += "Incorect apartmenNumber\n";
            if (!int.TryParse(str[2], out output)) e += "Incorect output\n";
            if (!int.TryParse(str[3], out input)) e += "Incorect input\n";
            if(e.Length != 0)
            {
                e += $"Line: {line}";
                throw new ArgumentException(e);
            }
            surname = str[1];
        }

        public int GetTheNumberOfUsedEnergy()
        {
            return output - input;
        }

        public override bool Equals(object obj)
        {
            if(obj is ClientInfo b)
            {
                if (this.apartmenNumber == b.apartmenNumber && this.surname == b.surname)
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            string result = String.Format("{0,-15} {1,-20} {2,-30} {3,-30}", apartmenNumber, surname, output, input);
            return result;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
