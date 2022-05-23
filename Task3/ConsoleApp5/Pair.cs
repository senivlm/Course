namespace Vector
{
    class Pair
    {
        private int number;
        private int frequency;

        public int Number { get => number; set => number = value; }
        public int Frequency { get => frequency; set => frequency = value; }

        public Pair(int number, int frequency)
        {
            this.Number = number;
            this.Frequency = frequency;
        }

        public Pair() : this(default, default)
        { 
        }


        public override string ToString()
        {
            return $"{Number} - {Frequency}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Pair)) return false;

            return (this.Number == ((Pair)obj).Number && this.Frequency == ((Pair)obj).Frequency);
        }
    }
}
