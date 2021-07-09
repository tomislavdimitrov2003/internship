using OnlineVoting.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Strategy
{
    class AddDeputy
    {
        public string Execute(Admin currentUser, string[] args)
        {
            string deputyName = args[1];
            int partyID = int.Parse(args[2]);
            
            currentUser.AddDeputy(deputyName, partyID);

            return "";
        }
    }
}
