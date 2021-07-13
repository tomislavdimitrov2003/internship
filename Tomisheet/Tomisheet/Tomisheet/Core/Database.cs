using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Models.TimesheetModels;
using Tomisheet.Models.UserModels;

namespace Tomisheet.Core
{
    public static class Database
    {
        private static Dictionary<int, User> users = new Dictionary<int, User>();
        private static Dictionary<int, Timesheet> timesheets = new Dictionary<int, Timesheet>();
        private static int lastUserID = 0;
        private static int lastTimesheetID = 0;

        public static Dictionary<int, User> Users { get => users; set => users = value; }
        public static int LastUserID { get => lastUserID; set => lastUserID = value; }
        public static Dictionary<int, Timesheet> Timesheets { get => timesheets; set => timesheets = value; }
        public static int LastTimesheetID { get => lastTimesheetID; set => lastTimesheetID = value; }

        public static void Clear() 
        {
            Users.Clear();
            Timesheets.Clear();
            LastUserID = 0;
            LastTimesheetID = 0;
        }
    }
}
