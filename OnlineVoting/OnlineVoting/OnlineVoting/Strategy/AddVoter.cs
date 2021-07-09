using OnlineVoting.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Strategy
{
    class AddVoter
    {
        public string Execute(Admin currentUser, string[] args)
        {
            string voterName = args[1];
            string voterGender = args[2];
            int voterAge = int.Parse(args[3]);

            currentUser.AddVoter(voterName, voterGender, voterAge);

            return "";
        }
    }
}
