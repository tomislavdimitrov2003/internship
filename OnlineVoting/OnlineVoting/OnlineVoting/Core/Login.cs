using OnlineVoting.Models.UserModels.BaseUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Core
{
    public static class Login
    {
        public static void Log() 
        {
            string input = Console.ReadLine();
            string[] arguments = input.Split();
            User currentUser;

            if (arguments[0] == "LogAsAdmin")
            {
                currentUser = Database.Users[0];
            }
            else if (arguments[0] == "LogAsVoter")
            {
                currentUser = Database.Users[int.Parse(arguments[1])];
            }
            else 
            {
                currentUser = Database.Users[0];
            }

            Engine engine = new Engine();
            engine.Run(currentUser);
        }
    }
}
