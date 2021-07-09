using NUnit.Framework;
using OnlineVoting.Core;
using OnlineVoting.Models.PartyModels;
using OnlineVoting.Models.UserModels.BaseUser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVotingTest
{
    [TestFixture]
    public class UserTest
    {
        [Test]
        public void GetPartiesTest()
        {
            //Arrange
            User user = new User(1, 1, "a", "b");
            Party first = new Party(1, "QWE", "zxc");
            Party second = new Party(2, "RTY", "vbn");
            Database.Parties.Add(1, first);
            Database.Parties.Add(2, second);

            //Act
            string result = user.GetParties();

            //Assert
            Assert.AreEqual("ID: 1 Name: QWE Location: zxc\nID: 2 Name: RTY Location: vbn\n", result);
            Database.Clear();

        }

        [Test]
        public void GetPartyTest()
        {
            //Arrange
            User user = new User(1, 1, "a", "b");
            Party party = new Party(1, "QWE", "zxc");
            Database.Parties.Add(1, party);

            //Act
            string result = user.GetParty(1);

            //Assert
            Assert.AreEqual("ID: 1 Name: QWE Location: zxc\n", result);
            Database.Clear();

        }

        [Test]
        public void GetDeputiesTest() 
        {
            //Arrange
            User user = new User(1, 1, "a", "b");
            Party first = new Party(1, "QWE", "zxc");
            first.Deputies.Add(1, new Deputy(1, "aaa"));
            first.Deputies.Add(2, new Deputy(2, "bbb"));
            Party second = new Party(2, "RTY", "vbn");
            second.Deputies.Add(1, new Deputy(1, "ccc"));
            Database.Parties.Add(1, first);
            Database.Parties.Add(2, second);

            //Act
            string result = user.GetDeputies();

            //Assert
            Assert.AreEqual("Deputies for QWE:\nName: aaa ID: 1\nName: bbb ID: 2\nDeputies for RTY:\nName: ccc ID: 1\n", result);
            Database.Clear();
        }

        [Test]
        public void GetDeputiesForPartyTest()
        {
            //Arrange
            User user = new User(1, 1, "a", "b");
            Party party = new Party(1, "QWE", "zxc");
            party.Deputies.Add(1, new Deputy(1, "aaa"));
            party.Deputies.Add(2, new Deputy(2, "bbb"));
            Database.Parties.Add(1, party);

            //Act
            string result = user.GetDeputiesForParty(1);

            //Assert
            Assert.AreEqual("Deputies for QWE:\nName: aaa ID: 1\nName: bbb ID: 2\n", result);
            Database.Clear();
        }

        [Test]
        public void WrongPartyIDTest()
        {
            //Arrange
            User user = new User(1, 1, "a", "b");
            int partyID = 5;

            //Assert
            Assert.Throws<System.Exception>(() => user.DoesPartyIDExist(partyID));
        }

        [Test]
        public void WrongVoterIDTest()
        {
            //Arrange
            User user = new User(1, 1, "a", "b");
            int voterID = 5;

            //Assert
            Assert.Throws<System.Exception>(() => user.DoesVoterIDExist(voterID));
        }

        [Test]
        public void WrongDeputyIDTest()
        {
            //Arrange
            User user = new User(1, 1, "a", "b");
            Database.Parties.Add(5, new Party(5, "a", "a"));
            int partyID = 5;
            int deputyID = 5;

            //Assert
            Assert.Throws<System.Exception>(() => user.DoesDeputyIDExist(partyID, deputyID));
            Database.Clear();
        }
    }
}
