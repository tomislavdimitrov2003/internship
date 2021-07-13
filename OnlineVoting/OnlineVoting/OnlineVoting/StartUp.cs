using OnlineVoting.Core;
using OnlineVoting.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Database.Users.Add(0, new Admin(0, 0, "Admin", "Admin"));

            Login.Log();
        }
    }
}
