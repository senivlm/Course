using System;

namespace Course.Task5
{
    class Vector
    {
        private int[] arr;

        public Vector()
        {
        }

        public Vector(int lenght)
        {
            arr = new int[lenght];
        }

        private void SwapByIndex(int aIndex, int bIndex)
        {
            int temp = arr[bIndex];
            arr[bIndex] = arr[aIndex];
            arr[aIndex] = temp;
        }

        private void BuiltHeap(int index, int lastIndex)
        {
            if (index * 2 + 1 >= lastIndex) return;

            BuiltHeap(index * 2 + 1, lastIndex);
            BuiltHeap(index * 2 + 2, lastIndex);

            int largestElemIndex = index;
            if (arr[largestElemIndex] < arr[index * 2 + 1]) largestElemIndex = index * 2 + 1;
            if (index * 2 + 2 <= lastIndex && arr[largestElemIndex] < arr[index * 2 + 2]) largestElemIndex = index * 2 + 2;
            if (largestElemIndex != index)
            {
                SwapByIndex(index, largestElemIndex);
            }
        }

        private void Heapsort(int lastIndex)
        {
            if (lastIndex <= 0) return;

            BuiltHeap(0, lastIndex);
            SwapByIndex(0, lastIndex);
            lastIndex--;
            Heapsort(lastIndex);
        }

        public void StartHeapSort()
        {
            Heapsort(arr.Length - 1);
        }

        public void RandInit(int minValue, int maxValue)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(minValue, maxValue + 1);
            }
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
