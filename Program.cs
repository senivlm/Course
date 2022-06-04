using System;
using System.Collections.Generic;
using System.IO;
using Course.Task6;

class Program
{
    static void Main(string[] args)
    {
        string b = Subtask2.ReadFromFile(@"../../../Task6/Subtask2/Text.txt");
        Subtask2.PrintTextToFileWhithSplit(@"../../../Task6/Subtask2/Result.txt", b);

        //    List<(string, int, double)> studentsData = new List<(string, int, double)>();

        //    try
        //    {
        //        using (StreamReader reader = new StreamReader(@"../../../data.txt"))
        //        {
        //            while (!reader.EndOfStream)
        //            {
        //                try
        //                {
        //                    string line = reader.ReadLine();
        //                    studentsData.Add(Parse(line));
        //                }
        //                catch (FormatException e)
        //                {
        //                    Console.WriteLine(e.Message);
        //                }
        //            }
        //        }
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        Console.WriteLine("File not found");
        //    }

        //    foreach ((string, int, double) i in studentsData) Console.WriteLine(i.Item1 + " | " + i.Item2 + " | " + i.Item3);
        //}

        //public static (string, int, double) Parse(string str)
        //{
        //    string[] vs = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        //    int year;
        //    double mark;
        //    string e = "";

        //    if (vs.Length != 3)
        //    {
        //        throw new FormatException($"Invalid string {str}");
        //    }

        //    if (!int.TryParse(vs[1], out year))
        //    {
        //        e += "Year exeption";
        //    }
        //    if (!double.TryParse(vs[2], out mark))
        //    {
        //        e += "Mark exeption";
        //    }
        //    if (e.Length != 0) throw new FormatException(e);

        //    return (vs[0], year, mark);
        //}
    }
}
