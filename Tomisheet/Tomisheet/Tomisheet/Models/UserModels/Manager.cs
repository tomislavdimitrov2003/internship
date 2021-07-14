using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Core;
using Tomisheet.Models.TimesheetModels;

namespace Tomisheet.Models.UserModels
{
    public class Manager : Employee
    {
        public Manager(int id, string name, List<int> teamIDs, int roleID, string password) : base(id, name, teamIDs, roleID, password)
        {
        }

        public string GetTeamTimeReport(DateTime startTime, DateTime endTime, string orderedBy, int teamID)
        {
            return Report.OrderedBy(orderedBy, Report.GetTeamTimeReport(startTime, endTime, teamID));
        }

        public string GetProjectTimeReport(DateTime startTime, DateTime endTime, string orderedBy, int projectID)
        {
            return Report.OrderedBy(orderedBy, Report.GetProjectTimeReport(startTime, endTime, projectID));
        }


    }
}
