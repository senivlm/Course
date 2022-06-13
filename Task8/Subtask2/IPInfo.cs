using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Course.Task8
{
    class IPInfo
    {
        private IPAddress ip;
        public List<(TimeSpan, DayOfWeek)> visitInf;

        public IPInfo()
        {
            ip = default;
            visitInf = new List<(TimeSpan, DayOfWeek)>();
        }

        public IPInfo(IPAddress ip, TimeSpan time, DayOfWeek day)
        {
            this.ip = ip;
            visitInf = new List<(TimeSpan, DayOfWeek)>();
            visitInf.Add((time, day));
        }

        public void AddInf(TimeSpan time, DayOfWeek day)
        {
            visitInf.Add((time, day));
        }

        public DayOfWeek FindMostPopularDay()
        {
            int dayIndex = (int)visitInf.GroupBy(g => g.Item2)
                .OrderByDescending(gh => gh.Count())
                .Select(g => g.Key).First();

            return (DayOfWeek)Enum.GetValues(typeof(DayOfWeek)).GetValue(dayIndex);
        }

        public int GetNumberOfVisits()
        {
            return visitInf.Count;
        }

        public int GetMostPopularHour()
        {
            return visitInf.GroupBy(g => g.Item1.Hours)
                .OrderByDescending(gp => gp.Count())
                .Select(g => g.Key).First();
        }

        public List<int> GetHours()
        {
            List<int> result = new List<int>();
            foreach((TimeSpan, DayOfWeek) i in visitInf)
            {
                result.Add(i.Item1.Hours);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is IPAddress i)
                if (i.Equals(ip)) return true;
            else if (obj is IPInfo j)
                if (j.ip.Equals(ip)) return true;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ip, visitInf);
        }
    }
}
