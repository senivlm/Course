using System;

namespace Course.Task2
{
    static class Check
    {
        static public void PrintCheck(Buy buy) => Console.WriteLine(buy + $"Загальна цiна: {buy.GetPrice()}\tЗагальна вага: {buy.GetWeight()}");

        static public void PrintProduct(Product product) => Console.WriteLine(product);
    }
}
