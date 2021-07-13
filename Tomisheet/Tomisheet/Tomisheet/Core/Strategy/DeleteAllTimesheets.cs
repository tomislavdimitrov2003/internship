using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Models.UserModels;

namespace Tomisheet.Core.Strategy
{
    class DeleteAllTimesheets
    {
        public string Execute(Employee currentUser, string[] args) 
        {
            currentUser.DeleteAllTimesheets();

            return "";
        }
    }
}
