using OnlineVoting.Models.UserModels.BaseUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Strategy
{
    class GetParty
    {
        public string Execute(User currentUser,string[] args)
        {
            int partyID = int.Parse(args[1]);

            return currentUser.GetParty(partyID);
        }
    }
}
