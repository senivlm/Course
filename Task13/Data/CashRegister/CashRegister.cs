using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task13
{
    class CashRegister
    {
        private double coord;
        private PriorityQueue<Person, Statuses> queuePersons;

        public bool isClosed;
        public bool isClosedByLimite;
        public int Count { get; private set;  }
        public Statuses StatuseSpecialization;
        public double Coord { get => coord; set => coord = value; }

        public CashRegister()
        {
            StatuseSpecialization = Statuses.Normal;
            queuePersons = new();
            isClosed = false;
            isClosedByLimite = false;
            Coord = 0;
            Count = 0;
        }

        public CashRegister(double coord, int limit)
        {
            StatuseSpecialization = Statuses.Normal;
            queuePersons = new();
            isClosed = false;
            isClosedByLimite = false;
            Coord = coord;
            Count = 0;
        }

        public bool IsEmpty()
        {
            return queuePersons.Count == 0;
        }

        public void Enqueue(Person person)
        {
            Count++;
            queuePersons.Enqueue(person, person.Status);
        }

        public Person Dequeue()
        {
            Count--;
            return queuePersons.Dequeue();
        }

        public Person Peek()
        {
            return queuePersons.Peek();
        }

        public override string ToString()
        {
            StringBuilder result = new();

            foreach (var item in queuePersons.UnorderedItems)
            {
                result.Append(item + " ");
            }

            return result.ToString();
        }
    }
}
