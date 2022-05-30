using System;
using Task5;

class Program
{
    static void Main(string[] args)
    {
        Task5.Vector a = new Task5.Vector(10);


        a.RandInit(0, 10);
        Console.WriteLine(a);
        a.StartHeapSort();

        Console.WriteLine(a);
    }
}
