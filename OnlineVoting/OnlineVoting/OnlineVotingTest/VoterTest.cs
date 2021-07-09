using NUnit.Framework;
using OnlineVoting.Core;
using OnlineVoting.Models.PartyModels;
using OnlineVoting.Models.UserModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVotingTest
{
    [TestFixture]
    public class VoterTest
    {
        [Test]
        public void VoteTest()
        {
            //Arrange
            Voter voter = new Voter(1, 1, "a", "b");
            Party party = new Party(1, "QWE", "zxc");
            party.Deputies.Add(1, new Deputy(1, "aaa"));
            Database.Parties.Add(1, party);

            //Act
            voter.Vote(1, 1);

            //Assert
            Assert.AreEqual(Database.Parties[1].Votes, 1);
        }
    }
}
