using OnlineVoting.Models.UserModels;
using OnlineVoting.Models.UserModels.BaseUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Strategy
{
    class Vote
    {
        public string Execute(Voter currentUser, string[] args)
        {
            int partyID = int.Parse(args[1]);
            int deputyID = int.Parse(args[2]);

            currentUser.Vote(partyID, deputyID);

            return "";
        }
    }
}
