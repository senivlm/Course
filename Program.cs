using System;
using Course.Task2;

class Program
{
    static void Main(string[] args)
    {
        Meat a = new Meat("a", 1, 2, Category.Category1, Sort.veal);
        Console.WriteLine(a);
    }
}
