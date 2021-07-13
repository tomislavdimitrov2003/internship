using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Models.UserModels;

namespace Tomisheet.Core.Strategy
{
    class GetTimeSpentForPeriodReport
    {
        public string Execute(Employee currentUser, string[] args) 
        {
            DateTime startTime = DateTime.Parse(args[1] + " " + args[2]);
            DateTime endTime = DateTime.Parse(args[3] + " " + args[4]);
            string orderedBy = args[5];

            string result = currentUser.GetTimeSpentForPeriodReport(startTime, endTime, orderedBy);

            return result;
        }
    }
}
