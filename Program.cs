using System;
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
        Subtask2 a = new Subtask2(@"../../../Task8/Subtask2/Info.txt");

        var r = a.GetMostPopularPeriod("129.2.32.43");
        var d = a.GetNumberOfVisit("129.2.32.43");
        var s = a.FindMostPopularDay("129.2.32.43");
        var l = a.GetMostPopularPeriodOnSite();

        int i = 0;
    }
}