using OnlineVoting.Core;
using OnlineVoting.Models.PartyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Models.UserModels.BaseUser
{
    public class User
    {
        private int id;
        private int age;
        private string name;
        private string gender;

        public User(int id,int age, string name, string gender)
        {
            this.ID = id;
            this.Age = age;
            this.Name = name;
            this.Gender = gender;
        }

        public int ID { get => id; set => id = value; }
        public int Age { get => age; set => age = value; }
        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }

        public string GetParties() 
        {
            string result = "";

            foreach (var party in Database.Parties.Values)
            {
                result += GetParty(party.ID);
            }

            return result;
        }

        public string GetParty(int partyID)
        {
            string result = Database.Parties[partyID].ToString() + "\n";

            return result;
        }

        public string GetDeputies() 
        {
            string result = "";
            
            foreach (Party party in Database.Parties.Values)
            {
                result += GetDeputiesForParty(party.ID);
            }

            return result;
        }

        public string GetDeputiesForParty(int partyID)
        {
            string result = "";
            
            result += "Deputies for " + Database.Parties[partyID].Name + ":\n";

            foreach (Deputy deputy in Database.Parties[partyID].Deputies.Values)
            {
                result += deputy.ToString() + "\n";
            }

            return result;
        }

        public void Exit() 
        {
            Login.Log();
        }

        public void DoesPartyIDExist(int partyID) 
        {
            if (!Database.Parties.ContainsKey(partyID)) 
            {
                throw (new Exception("Wrong PartyID."));
            }
        }

        public void DoesVoterIDExist(int voterID)
        {
            if (!Database.Users.ContainsKey(voterID))
            {
                throw (new Exception("Wrong VoterID."));
            }
        }

        public void DoesDeputyIDExist(int partyID, int deputyID)
        {
            DoesPartyIDExist(partyID);
            if (!Database.Parties[partyID].Deputies.ContainsKey(deputyID))
            {
                throw (new Exception("Wrong DeputyID."));
            }
        }
    }
}
