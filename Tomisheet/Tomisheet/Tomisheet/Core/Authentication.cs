using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Models.UserModels;

namespace Tomisheet.Core
{
    public static class Authentication
    {
        public static void Login() 
        {
            
            string input = Console.ReadLine();
            string[] args = input.Split();
            foreach (User user in Database.Users.Values)
            {
                if (user.Name == args[0] && user.Password == args[1]) 
                {
                    Engine.Run(user);
                }
            }
        }
    }
}
