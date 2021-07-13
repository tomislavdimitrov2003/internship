using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Models.UserModels;

namespace Tomisheet.Core.Strategy
{
    class DeleteTimesheetRecord
    {
        public string Execute(Employee currentUser, string[] args)
        {
            int timesheetID = int.Parse(args[1]);
            int rowID = int.Parse(args[2]);

            currentUser.DeleteTimesheetRecord(timesheetID, rowID);

            return "";
        }
    }
}
