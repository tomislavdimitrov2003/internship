using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Core;
using Tomisheet.Models.TimesheetModels;

namespace Tomisheet.Models.UserModels
{
    public class User
    {
        private int id;
        private string name;
        private List<int> teamIDs = new List<int>();
        private int roleID;
        private string password;
        private List<int> timesheetIDs = new List<int>();

        public User(int id, string name, List<int> teamIDs, int roleID, string password)
        {
            this.ID = id;
            this.Name = name;
            this.TeamIDs = teamIDs;
            this.RoleID = roleID;
            this.Password = password;
        }

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public List<int> TeamIDs { get => teamIDs; set => teamIDs = value; }
        public int RoleID { get => roleID; set => roleID = value; }
        public string Password { get => password; set => password = value; }
        public List<int> TimesheetIDs { get => timesheetIDs; set => timesheetIDs = value; }

        public void LogOut() 
        {
            Authentication.Login();
        }
    }
}
