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
    public class Admin : User
    {
        public Admin(int id, int age, string name, string gender) : base(id, age, name, gender)
        {

        }

        public void AddVoter(string voterName, string voterGender, int voterAge)
        {
            Database.LastUserID++;
            Database.Users.Add(Database.LastUserID, new Voter(Database.LastUserID, voterAge, voterName, voterGender));
        }

        public void DeleteVoter(int voterID)
        {
            DoesVoterIDExist(voterID);

            Database.Users.Remove(voterID);
        }

        public void AddParty(string partyName, string partyLocation)
        {
            Database.LastPartyID++;
            Database.Parties.Add(Database.LastPartyID, new Party(Database.LastPartyID, partyName, partyLocation));
        }

        public void DeleteParty(int partyID)
        {
            DoesPartyIDExist(partyID);

            Database.Parties.Remove(partyID);
        }

        public void EditParty(int partyID, string partyName, string partyLocation)
        {
            DoesPartyIDExist(partyID);

            Database.Parties[partyID].Name = partyName;
            Database.Parties[partyID].Location = partyLocation;
        }

        public string GetAllVoters()
        {
            string result = "";

            foreach (Voter user in Database.Users.Values.Skip(1))
            {
                result += user.ToString() + "\n";
            }

            return result;
        }

        public void AddDeputy(string deputyName, int partyID)
        {
            DoesPartyIDExist(partyID);

            Database.Parties[partyID].LastDeputyID++;
            Database.Parties[partyID].Deputies.Add(Database.Parties[partyID].LastDeputyID, new Deputy(Database.Parties[partyID].LastDeputyID, deputyName));
        }

        public void DeleteDeputy(int partyID, int deputyID)
        {
            DoesDeputyIDExist(partyID, deputyID);

            Database.Parties[partyID].Deputies.Remove(deputyID);
        }

        public void EditDeputy(int partyID, int deputyID, string deputyName)
        {
            DoesDeputyIDExist(partyID, deputyID);

            Database.Parties[partyID].Deputies[deputyID].Name = deputyName;
        }

        public string GetVotingResults()
        {
            string result = "";

            foreach (Party party in Database.Parties.Values)
            {
                result += GetVotesCountForParty(party.ID) + GetVotesCountForPartyPerDeputy(party.ID);
            }

            return result;
        }

        public string GetVotesCountForParty(int partyID)
        {
            DoesPartyIDExist(partyID);

            return (Database.Parties[partyID].Name + " have "+ Database.Parties[partyID].Votes + " Votes.\n");
        }

        public string GetVotesCountForPartyPerDeputy(int partyID) 
        {
            DoesPartyIDExist(partyID);

            string result = "";

            foreach (Deputy deputy in Database.Parties[partyID].Deputies.Values)
            {
                result += deputy.Name + " has " + deputy.Votes + " Votes.\n";
            }

            return result;
        }

    }
}
