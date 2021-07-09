using OnlineVoting.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Strategy
{
    class EditParty
    {
        public string Execute(Admin currentUser, string[] args)
        {
            int partyID = int.Parse(args[1]);
            string partyName = args[2];
            string partyLocation = args[3];

            currentUser.EditParty(partyID, partyName, partyLocation);

            return "";
        }
    }
}
