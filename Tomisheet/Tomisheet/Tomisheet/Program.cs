using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Core;
using Tomisheet.Models.UserModels;

namespace Tomisheet
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> teamIDs = new List<int>();
            teamIDs.Add(0);
            string password = Authentication.HashPassword("admin");
            Database.Users.Add(0, new Admin(0, "Admin", teamIDs, 3, password));
            Authentication.Login();
        }
    }
}
