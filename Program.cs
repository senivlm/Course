﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Course.Task8;
using VectorNamespace;

class Program
{
    static void Main(string[] args)
    {
        //Subtask2 a = new Subtask2(@"../../../Task8/Subtask2/Info.txt");

        //var r = a.GetMostPopularPeriod("129.2.32.43");
        //var d = a.GetNumberOfVisit("129.2.32.43");
        //var s = a.FindMostPopularDay("129.2.32.43");
        //var l = a.GetMostPopularPeriodOnSite();

        Meat c = new Meat("Name1", 14, 25, Category.Category2, Sort.Pork);
        Meat d = new Meat("Name1", 14, 25, Category.Category2, Sort.Pork);
        Meat v = new Meat("Name4", 13, 2, Category.Category1, Sort.Mutton);

        Subtask3 a = new Subtask3(@"../../../Task8/Subtask3/Products.txt");
        Subtask3 b = new Subtask3(c, v, d);

        var k = a.Except(b);
        var l = a.Intersect(b);
        var z = a.Union(b);


        int i = 0;
    }
}