using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task9
{
    struct Ingridient
    {
        public string name { get; }
        public float price { get; }

        public Ingridient(string name, float price)
        {
            this.name = name;
            this.price = price;
        }

        public Ingridient(string line)
        {
            var values = line.Split('-');
            if (values.Length != 2) throw new ArgumentException($"Incorrect line {line}");
            float tempPrice = 0;
            if (!float.TryParse(values[1], out tempPrice)) throw new ArgumentException($"Incorrect price for {values[0]}");
            this.name = values[0];
            price = tempPrice;
        }

        public override bool Equals(object obj)
        {
            if (obj is Ingridient ingridient) return ingridient.name == this.name;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, price);
        }

        public override string ToString()
        {
            return name;
        }
    }
}
