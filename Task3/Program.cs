using System;

namespace Vector
{
    enum StartTurn
    {
        right,
        down
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vector arr = new Vector(10);

            arr.RandInit(0, 10);

            Console.WriteLine(arr);
            Console.WriteLine();

            int[] a = arr.LongestSequence();

            Array.Reverse(a); // Приклад виконання стандартного reverse

            foreach (int i in a) Console.Write(i + " ");
            Console.WriteLine("\n");

            SquereMatrix matrix = new SquereMatrix(10, StartTurn.down);

            matrix.FillMatrix();

            Console.Write(matrix);
        }
    }
}