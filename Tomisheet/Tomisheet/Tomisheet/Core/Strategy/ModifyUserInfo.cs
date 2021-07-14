using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Models.UserModels;

namespace Tomisheet.Core.Strategy
{
    public class ModifyUserInfo
    {
        public string Execute(Admin currentUser, string[] args) 
        {
            int userID = int.Parse(args[1]);
            string name = args[2];

            currentUser.ModifyUserInfo(userID, name);

            return "User Info Modified.\n";
        }
    }
}
