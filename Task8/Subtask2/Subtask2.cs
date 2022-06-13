using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Course.Task8
{
    class Subtask2
    {
        List<IPInfo> visitorsInf;

        #region Constructors
        public Subtask2()
        {
            visitorsInf = new List<IPInfo>();
        }

        public Subtask2(IPAddress ip, TimeSpan time, DayOfWeek day)
        {
            visitorsInf = new List<IPInfo>();
            visitorsInf.Add(new IPInfo(ip, time, day));
        }

        public Subtask2(string filePath)
        {
            visitorsInf = new List<IPInfo>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    try
                    {
                        IPAddress ip;
                        TimeSpan time;
                        string exeptions = "";
                        DayOfWeek day = default;
                        bool isExist = false;

                        var str = line.Split();

                        if (str[2][0] != char.ToUpper(str[2][0])) str[2] = char.ToUpper(str[2][0]) + str[2].Substring(1);

                        if (IPAddress.TryParse(str[0], out ip)) 
                            exeptions += "Incorect ip|";
                        if (TimeSpan.TryParse(str[1], out time)) 
                            exeptions += "Incorect time|";

                        if (!Enum.IsDefined(typeof(DayOfWeek), str[2])) 
                            exeptions += "Incorect day of week";
                        else 
                            day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), str[2]);

                        if (exeptions == string.Empty) throw new ArgumentException(exeptions);

                        foreach(IPInfo i in visitorsInf)
                        {
                            if (i.Equals(ip))
                            {
                                i.AddInf(time, day);
                                isExist = true;
                            }
                        }
                        if(!isExist) visitorsInf.Add(new IPInfo(ip, time, day));
                    }
                    catch (ArgumentException)
                    {
                        throw;
                    }
                }
            }
        }
        #endregion

        public int GetNumberOfVisit(string ip)
        {
            IPAddress iPAddress = IPAddress.Parse(ip);
            return visitorsInf.Find(x => x.Equals(iPAddress)).GetNumberOfVisits();
        }

        public string FindMostPopularDay(string ip)
        {
            IPAddress iPAddress = IPAddress.Parse(ip);
            return Enum.GetName(typeof(DayOfWeek), visitorsInf.Find(x => x.Equals(iPAddress))
                                                                .FindMostPopularDay());
        }

        //  Return a hour when period start
        public int GetMostPopularPeriod(string ip)
        {
            IPAddress iPAddress = IPAddress.Parse(ip);
            return visitorsInf.Find(x => x.Equals(iPAddress)).GetMostPopularHour();
        }

        public int GetMostPopularPeriodOnSite()
        {
            List<int> hours = new List<int>();

            foreach(IPInfo i in visitorsInf)
            {
                hours.AddRange(i.GetHours());
            }

            int result = hours.GroupBy(g => g)
                .OrderByDescending(gh => gh.Count())
                .Select(g => g.Key).First();

            return result;
        }
    }
}
