using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workload.WebApi.Helpers
{
    public static class Helper
    {
        public static double GetDailyWorkLoad(string start,string end, double totalHours)
        {
            var endDate = DateTime.Parse(end);
            var startDate = DateTime.Parse(start);
            return totalHours / ((endDate - startDate).Days + 1);
        }
    }
}
