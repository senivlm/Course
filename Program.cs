using System;
using System.Collections.Generic;
using System.IO;
using Course.Task7;

class Program
{
    static void Main(string[] args)
    {
        Storage a = new Storage(@"../../../Task7/Products.txt");

        ErrorHandler.ChangeErrors("6 06 2022", a);

        Console.WriteLine(a);
    }
}
