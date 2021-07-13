using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Core;

namespace Tomisheet.Models.UserModels
{
    public class Admin : Manager
    {
        public Admin(int id, string name, List<int> teamIDs, int roleID, string password) : base(id, name, teamIDs, roleID, password)
        {
        }

        public void AddUser(string name, string password, List<int> TeamIDs, int roleID)
        {
            Database.LastUserID++;
            if (roleID == 1) 
            {
                Database.Users.Add(Database.LastUserID, new Employee(Database.LastUserID, name, TeamIDs, roleID, password));
            }
            else if (roleID == 2) 
            {
                Database.Users.Add(Database.LastUserID, new Manager(Database.LastUserID, name, TeamIDs, roleID, password));
            }
            else if (roleID == 3) 
            {
                Database.Users.Add(Database.LastUserID, new Admin(Database.LastUserID, name, TeamIDs, roleID, password));
            }
        }

        public void ModifyUserInfo(int userID, string name)
        {
            Database.Users[userID].Name = name;
        }

        public void ChangeUserPassword(int userID, string password) 
        {
            Database.Users[userID].Password = password;
        }

        public void DeleteUser(int userID)
        {
            Database.Users.Remove(userID);
        }
    }
}
