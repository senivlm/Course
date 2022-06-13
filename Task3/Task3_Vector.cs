using System;

namespace VectorNamespace
{
    class Vector
    {
        private int[] arr;

        public Vector()
        {
            arr = Array.Empty<int>();
        }

        public Vector(int lenght)
        {
            arr = new int[lenght];
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                {
                    return arr[index];
                }
                else
                {
                    throw new Exception("Index out of range");
                }
            }
            set
            {
                arr[index] = value;
            }
        }

        public void RandInit(int minValue, int maxValue)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(minValue, maxValue + 1);
            }
        }

        // SUBTASK 1
        public bool PalindromCheck()
        {
            int j = arr.Length - 1;
            for (int i = 0; i <= arr.Length / 2; i++, j--)
            {
                if (arr[i] != arr[j])
                {
                    return false;
                }
            }
            return true;
        }
        ////////////////////////////////////////////////////

        //SUBTASK 2
        public void Reverse()
        {
            int temp = 0;
            int j = arr.Length - 1;
            for (int i = 0; i <= arr.Length / 2; i++, j--)
            {
                temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        public void SReverse()
        {
            Array.Reverse(arr);
        }
        /////////////////////////////////////////////////////

        // SUBTASK 3
        public int[] LongestSequence()
        {
            int startOfSequence = 0;
            int sequenceLenght = 0;
            int startOfCurrentSequence = 0;
            int currentNumber = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == currentNumber)
                {
                    continue;
                }
                else
                {
                    if (sequenceLenght < i - startOfCurrentSequence)
                    {
                        sequenceLenght = i - startOfCurrentSequence;
                        startOfSequence = startOfCurrentSequence;
                    }
                    currentNumber = arr[i];
                    startOfCurrentSequence = i;
                }
            }

            int[] result = new int[sequenceLenght];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = arr[i + startOfSequence];
            }

            return result;
        }
        ////////////////////////////////////////////////////////////////

        // SUBTASK 5
        public void ShufleInit()
        {
            bool[] isNumberExist = new bool[arr.Length]; // index = Number ([0] = 1)
            Random rand = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                while (true)
                {
                    int r = rand.Next(1, arr.Length + 1);
                    if (!isNumberExist[r - 1])
                    {
                        arr[i] = r;
                        isNumberExist[r - 1] = true;
                        break;
                    }
                }
            }
        }
        ////////////////////////////////////////////////

        public Pair[] CalculateFrequency()
        {
            Pair[] pairs = new Pair[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                pairs[i] = new Pair(0, 0);

            }
            int countDifference = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if (arr[i] == pairs[j].Number)
                    {
                        pairs[j].Frequency++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDifference].Frequency++;
                    pairs[countDifference].Number = arr[i];
                    countDifference++;
                }
            }

            Pair[] result = new Pair[countDifference];
            for (int i = 0; i < countDifference; i++)
            {
                result[i] = pairs[i];
            }

            return result;
        }

        public static explicit operator Vector(int a)
        {
            Vector result = new Vector(a);
            for(int i = 0; i < result.arr.Length; i++)
            {
                result[i] = a; 
            }

            return result;
        }

        public static implicit operator int(Vector a)
        {
            return a[0];
        }

        public static bool operator>(Vector a, Vector b)
        {
            return a.arr.Length > b.arr.Length;
        }

        public static bool operator <(Vector a, Vector b)
        {
            return a.arr.Length < b.arr.Length;
            //return !(a > b);
        }

        public static Vector operator +(Vector a, int b)
        {
            Vector result = new Vector(a.arr.Length);

            for (int i = 0; i < result.arr.Length; i++)
            {
                result[i] = a[i] + b;
            }

            return result;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            Vector result;
            //int lowerLenght = 0;
            //int index = 0;
            //bool isALonger = false;
            //if (a.arr.Length > b.arr.Length)
            //{
            //    result = new Vector(a.arr.Length);
            //    lowerLenght = b.arr.Length;
            //    isALonger = true;
            //}
            //else
            //{
            //    result = new Vector(b.arr.Length);
            //    lowerLenght = a.arr.Length;
            //}

            //for (; index < lowerLenght; index++)
            //{
            //    result[index] = b[index] + a[index];
            //}

            if (a.arr.Length > b.arr.Length)
            {
                (a, b) = (b, a);
            }
            result = new Vector(b.arr.Length);

            for (int i = 0; i < a.arr.Length; i++)
            {
                result[i] = a[i] + b[i];
            }
            for (int i = a.arr.Length; i < result.arr.Length; i++)
            {
                result[i] = b[i];
            }

            //if (isALonger) {
            //    for (; index < result.arr.Length; index++)
            //    {
            //        result[index] = a[index];
            //    }
            //}
            //else
            //{
            //    for (; index < result.arr.Length; index++)
            //    {
            //        result[index] = b[index];
            //    }
            //}

            return result;
        }

        public override string ToString()
        {
            string arrLine = "";
            foreach (int a in arr)
            {
                arrLine += a + " ";
            }
            return arrLine;
        }
    }
}
