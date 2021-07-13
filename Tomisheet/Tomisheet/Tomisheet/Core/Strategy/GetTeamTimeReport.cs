﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Models.UserModels;

namespace Tomisheet.Core.Strategy
{
    class GetTeamTimeReport
    {
        public string Execute(Manager currentUser, string[] args)
        {
            DateTime startTime = DateTime.Parse(args[1] + " " + args[2]);
            DateTime endTime = DateTime.Parse(args[3] + " " + args[4]);
            string orderedBy = args[5];
            int teamID = int.Parse(args[6]);

            string result = currentUser.GetTeamTimeReport(startTime, endTime, orderedBy, teamID);

            return result;
        }
    }
}