using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Models.UserModels;

namespace Tomisheet.Core.Strategy
{
    class CreateTimesheet
    {
        public string Execute(Employee currentUser, string[] args) 
        {
            string name = args[1];

            currentUser.CreateTimesheet(name);

            return "Timesheet Created.\n";
        }
    }
}
