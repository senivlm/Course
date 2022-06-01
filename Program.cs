using System;
using Course.Task2;

class Program
{
    static void Main(string[] args)
    {
        Meat a = new Meat("a", 23, 3, Category.Category1, Sort.mutton);
        DairyProducts b = new DairyProducts("b", 3, 1, 3);

        Storage c = new Storage(a, b);

        c.PrintInfo();
    }
}
