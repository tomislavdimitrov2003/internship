using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Models.UserModels;

namespace Tomisheet.Core.Strategy
{
    class EditTimesheetRecord
    {
        public string Execute(Employee currentUser, string[] args)
        {
            int timesheetID = int.Parse(args[1]);
            int rowID = int.Parse(args[2]);
            int projectID = int.Parse(args[3]);
            string taskName = args[4];
            DateTime startTime = DateTime.Parse(args[5] + " " + args[6]);
            DateTime endTime = DateTime.Parse(args[7] + " " + args[8]);

            currentUser.EditTimesheetRecord(timesheetID, rowID, projectID, taskName, startTime, endTime);

            return "Timesheet Record Edited.\n";
        }
    }
}
