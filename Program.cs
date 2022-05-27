using System;
using System.Collections.Generic;
using Course.Task2;

class Program
{
    static void Main(string[] args)
    {
        Meat a = new Meat("a", 40, 3, Category.Category1, Sort.mutton);
        DairyProducts b = new DairyProducts("b", 40, 3, 4);

        Storage c = new Storage(a, b);
        Console.WriteLine(c);

        UserInterface.AddProductsToStorage(c);

        Console.WriteLine(c);
    }
}
