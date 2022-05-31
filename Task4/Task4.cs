using System;

namespace Task4
{
    enum Element
    {
        start,
        middle,
        end
    }

    class Vector
    {
        private int[] arr;
// неправильний конструктор
        public Vector()
        {
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
            {// теж треба контролювати індекси
                arr[index] = value;
            }
        }

        private void SwapByIndex(int aIndex, int bIndex)
        {
            int temp = arr[bIndex];
            arr[bIndex] = arr[aIndex];
            arr[aIndex] = temp;
        }

        private int SelectionByLast(int elementIndex, int startIndex, int endIndex)
        {
            int i = startIndex;
            int p = arr[elementIndex];
            for (int j = startIndex; j < endIndex; j++)
            {
                if (arr[j] <= p)
                {
                    SwapByIndex(i, j);
                    i++;
                }
            }

            SwapByIndex(i, elementIndex);
            return (i);
        }

        private int Selection(int elementIndex, int startIndex, int endIndex)
        {
            int p = arr[elementIndex];
            int i = startIndex;
            int j = endIndex;
            while (true)
            {
                while (arr[i] < p)
                {
                    i++;
                }
                while (arr[j] > p)
                {
                    j--;
                }
                if (i >= j)
                {
                    return j;
                }

                SwapByIndex(i++, j--);
            }
        }

        private void QuickSort(int startIndex, int endIndex, Element element)
        {
            if (startIndex < endIndex)
            {
                int p = 0;
                switch (element)
                {
                    case Element.start:
                        p = Selection(startIndex, startIndex, endIndex);
                        break;
                    case Element.middle:
                        p = Selection((startIndex + endIndex) / 2, startIndex, endIndex);
                        break;
                    case Element.end:
                        p = SelectionByLast(endIndex, startIndex, endIndex);
                        //Це лишнє
                        QuickSort(startIndex, p - 1, element);
                        QuickSort(p + 1, endIndex, element);
                        return;
                }

                QuickSort(startIndex, p, element);
                QuickSort(p + 1, endIndex, element);
            }
        }

        public void StartQuickSort(Element element)
        {
            QuickSort(0, arr.Length - 1, element);
        }

        public void RandInit(int minValue, int maxValue)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(minValue, maxValue + 1);
            }
        }
    }
}
