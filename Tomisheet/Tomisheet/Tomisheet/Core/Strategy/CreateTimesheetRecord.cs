using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Models.UserModels;

namespace Tomisheet.Core.Strategy
{
    public class CreateTimesheetRecord
    {
        public string Execute(Employee currentUser, string[] args) 
        {
            int timesheetID = int.Parse(args[1]);
            int projectID = int.Parse(args[2]);
            string taskName = args[3];
            DateTime startTime = DateTime.Parse(args[4] + " " + args[5]);
            DateTime endTime = DateTime.Parse(args[6] + " " + args[7]);
            

            currentUser.CreateTimesheetRecord(timesheetID, projectID, taskName, startTime, endTime);

            return "Timesheet Record Created.\n";
        }
    }
}
