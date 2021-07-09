using OnlineVoting.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Strategy
{
    class DeleteVoter
    {
        public string Execute(Admin currentUser, string[] args)
        {
            int voterID = int.Parse(args[1]);

            currentUser.DeleteVoter(voterID);

            return "";
        }
    }
}
