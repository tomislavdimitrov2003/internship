using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            string savedPasswordHash = Authentication.HashPassword(password);
            Database.LastUserID++;
            if (roleID == (int) UserRoleIDs.Employee)
            {
                Database.Users.Add(Database.LastUserID, new Employee(Database.LastUserID, name, TeamIDs, roleID, savedPasswordHash));
            }
            else if (roleID == (int) UserRoleIDs.Manager)
            {
                Database.Users.Add(Database.LastUserID, new Manager(Database.LastUserID, name, TeamIDs, roleID, savedPasswordHash));
            }
            else if (roleID == (int) UserRoleIDs.Admin)
            {
                Database.Users.Add(Database.LastUserID, new Admin(Database.LastUserID, name, TeamIDs, roleID, savedPasswordHash));
            }
            else 
            {
                throw (new Exception("Invalid RoleID"));
            }
        }

        public void ModifyUserInfo(int userID, string name)
        {
            Database.Users[userID].Name = name;
        }

        public void ChangeUserPassword(int userID, string password) 
        {
            string savedPasswordHash = Authentication.HashPassword(password);
            Database.Users[userID].Password = savedPasswordHash;
        }

        public void DeleteUser(int userID)
        {
            Database.Users.Remove(userID);
        }
    }
}
