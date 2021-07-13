using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Models.TimesheetModels;

namespace Tomisheet.Core
{
    public static class Report
    {
        public static List<Row> GetTimeSpentForPeriodReport(DateTime startTime, DateTime endTime, int userID) 
        {
            List<Row> result = new List<Row>();


            foreach (Row row in GetTimeReport(startTime, endTime))
            {
                if (userID == row.UserID) 
                {
                    result.Add(row);
                }
            }

            return result;
        }

        public static List<Row> GetTeamTimeReport(DateTime startTime, DateTime endTime, int teamID)
        {
            List<Row> result = new List<Row>();


            foreach (Row row in GetTimeReport(startTime, endTime))
            {
                if (Database.Users[row.UserID].TeamIDs.Contains(teamID))
                {
                    result.Add(row);
                }
            }

            return result;
        }

        public static List<Row> GetProjectTimeReport(DateTime startTime, DateTime endTime, int projectID)
        {
            List<Row> result = new List<Row>();

            foreach (Row row in GetTimeReport(startTime, endTime))
            {
                if (projectID == row.ProjectID)
                {
                    result.Add(row);
                }
            }

            return result;
        }

        public static List<Row> GetTimeReport(DateTime startTime, DateTime endTime)
        {
            List<Row> result = new List<Row>();

            foreach (Timesheet timesheet in Database.Timesheets.Values)
            {
                List<Row> rows = (timesheet.Rows.Values).ToList().FindAll(x => x.StartTime >= startTime && x.EndTime <= endTime);
                result.AddRange(rows);
            }

            return result;
        }

        public static string SortListByTask(List<Row> rows) 
        {
            rows = rows.OrderBy(x => x.TaskName).ToList();
            string result = "";

            foreach (Row row in rows)
            {
                result += row.ToString();
            }

            return result;
        }

        public static string SortListByPerson(List<Row> rows)
        {
            rows = rows.OrderBy(x => x.UserID).ToList();
            string result = "";

            foreach (Row row in rows)
            {
                result += row.ToString();
            }

            return result;
        }

        public static string SortListByDuration(List<Row> rows)
        {
            rows = rows.OrderBy(x => x.Duration).ToList();
            string result = "";

            foreach (Row row in rows)
            {
                result += row.ToString();
            }

            return result;
        }

        public static string OrderedBy(string orderedBy, List<Row> rows)
        {
            string result = "";

            switch (orderedBy)
            {
                case "Task":
                    result = SortListByTask(rows);
                    break;
                case "Person":
                    result = SortListByPerson(rows);
                    break;
                case "Duration":
                    result = SortListByDuration(rows);
                    break;
            }

            return result;
        }
    }
}
