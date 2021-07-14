using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Core;
using Tomisheet.Models.TimesheetModels;

namespace Tomisheet.Models.UserModels
{
    public class Employee : User
    {
        public Employee(int id, string name, List<int> teamIDs, int roleID, string password) : base(id, name, teamIDs, roleID, password)
        {
        }

        public void CreateTimesheet(string name) 
        {
            Database.LastTimesheetID++;
            Database.Timesheets.Add(Database.LastTimesheetID, new Timesheet(Database.LastTimesheetID, ID, name));
            TimesheetIDs.Add(Database.LastTimesheetID);
        }

        public void DeleteTimesheet(int id) 
        {
            Database.Timesheets.Remove(id);
            TimesheetIDs.Remove(id);
        }

        public void DeleteAllTimesheets() 
        {
            foreach (int id in TimesheetIDs)
            {
                DeleteTimesheet(id);
            }
        }
        public void CreateTimesheetRecord(int timesheetID, int projectID, string taskName, DateTime startTime, DateTime endTime)
        {
            Database.Timesheets[timesheetID].LastRowID++;
            Row newRow = new Row(Database.Timesheets[timesheetID].LastRowID, ID, projectID, taskName, startTime, endTime);
            Database.Timesheets[timesheetID].Rows.Add(Database.Timesheets[timesheetID].LastRowID, newRow);
        }

        public void EditTimesheetRecord(int timesheetID, int rowID, int projectID, string taskName, DateTime startTime, DateTime endTime)
        {
            Database.Timesheets[timesheetID].Rows[rowID] = new Row(rowID, ID, projectID, taskName, startTime, endTime);
        }

        public void DeleteTimesheetRecord(int timesheetID, int rowID) 
        {
            Database.Timesheets[timesheetID].Rows.Remove(rowID);
        }

        public string GetTimeSpentForPeriodReport(DateTime startTime, DateTime endTime, string orderedBy) 
        {
            return Report.OrderedBy(orderedBy, Report.GetTimeSpentForPeriodReport(startTime, endTime, ID));
        }
    }
}
