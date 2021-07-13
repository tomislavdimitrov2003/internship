using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Models.UserModels;

namespace Tomisheet.Core.Strategy
{
    class LogOut
    {
        public string Execute(User currentUser, string[] args) 
        {
            currentUser.LogOut();

            return "Logged Out.\n";
        }
    }
}
