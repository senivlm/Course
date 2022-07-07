using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task13
{
    class Person
    {
        private Guid Id { get; }
        private int age;
        private string name;
        private Statuses status;
        private double coordinate;
        int timeServise;

        public int TimeServise
        {
            get => timeServise;
            set
            {
                timeServise = value;
            }
        }

        public int Age { get => age; }
        public string Name { get => name; }
        public Statuses Status { get => status; }
        public double Coordinate { get => coordinate; }

        public Person() : this(default, "", default, default, default) { }

        public Person(Person person)
        {
            Id = Guid.NewGuid();
            this.age = person.age;
            this.name = person.name;
            this.status = person.status;
            this.coordinate = person.coordinate;
            this.timeServise = person.timeServise;
        }

        public Person(Statuses status, string name, int age, double coordinate, int timeServise)
        {
            Id = Guid.NewGuid();
            this.age = age;
            this.name = name;
            this.status = status;
            this.coordinate = coordinate;
            this.timeServise = timeServise;
        }

        public override string ToString()
        {
            return $"{name} : {age}";
        }
    }
}
