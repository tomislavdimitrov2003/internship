using OnlineVoting.Core;
using OnlineVoting.Models.PartyModels;
using OnlineVoting.Models.UserModels.BaseUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Models.UserModels
{
    public class Voter : User
    {
        bool hasVoted = false;

        public Voter(int id, int age, string name, string gender) : base(id, age, name, gender)
        {
        }

        public void Vote(int partyID, int deputyID) 
        {
            if (!hasVoted && Age >= 18) 
            {
                DoesDeputyIDExist(partyID, deputyID);
                Database.Parties[partyID].Votes++;
                Database.Parties[partyID].Deputies[deputyID].Votes++;
                hasVoted = true;
            }
        }

        public override string ToString() 
        {
            return "ID: " + this.ID + " Name: " + this.Name + " Age: " + this.Age + " Gender: " + this.Gender;
        }
    }
}
