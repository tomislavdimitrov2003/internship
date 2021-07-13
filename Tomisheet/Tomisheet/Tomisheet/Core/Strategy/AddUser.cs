using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Models.UserModels;

namespace Tomisheet.Core.Strategy
{
    public class AddUser
    {
        public string Execute(Admin currentUser, string[] args) 
        {
            string name = args[1];
            string password = args[2];
            int roleID = int.Parse(args[3]);
            List<int> teamIDs = new List<int>();

            foreach (string arg in args.Skip(4))
            {
                teamIDs.Add(int.Parse(arg));
            }

            currentUser.AddUser(name, password, teamIDs, roleID);

            return "User Added.\n";
        }
    }
}
