using OnlineVoting.Models.UserModels.BaseUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Strategy
{
    class GetDeputies
    {
        public string Execute(User currentUser, string[] args)
        {
            return currentUser.GetDeputies();
        }
    }
}
