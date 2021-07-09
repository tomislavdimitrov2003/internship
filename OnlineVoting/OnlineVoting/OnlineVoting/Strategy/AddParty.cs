using OnlineVoting.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Strategy
{
    class AddParty
    {
        public string Execute(Admin currentUser, string[] args)
        {
            string partyName = args[1];
            string partyLocation = args[2];

            currentUser.AddParty(partyName, partyLocation);

            return "";
        }
    }
}
