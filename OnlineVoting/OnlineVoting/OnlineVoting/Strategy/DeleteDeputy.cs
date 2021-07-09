using OnlineVoting.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Strategy
{
    class DeleteDeputy
    {
        public string Execute(Admin currentUser, string[] args)
        {
            int partyID = int.Parse(args[1]);
            int deputyID = int.Parse(args[2]);

            currentUser.DeleteDeputy(partyID, deputyID);

            return "";
        }
    }
}
