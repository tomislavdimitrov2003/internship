using OnlineVoting.Models.UserModels.BaseUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Strategy
{
    class Exit
    {
        public string Execute(User currentUser, string[] args)
        {
            currentUser.Exit();

            return "";
        }
    }
}
