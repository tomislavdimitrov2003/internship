using OnlineVoting.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Strategy
{
    class GetAllVoters
    {
        public string Execute(Admin currentUser, string[] args)
        {
            return currentUser.GetAllVoters();
        }
    }
}
