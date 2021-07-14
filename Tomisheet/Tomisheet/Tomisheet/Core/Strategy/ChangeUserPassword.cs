using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Models.UserModels;

namespace Tomisheet.Core.Strategy
{
    public class ChangeUserPassword
    {
        public string Execute(Admin currentUser, string[] args) 
        {
            int userID = int.Parse(args[1]);
            string password = args[2];

            currentUser.ChangeUserPassword(userID, password);

            return "Password Changed.\n";
        }
    }
}
