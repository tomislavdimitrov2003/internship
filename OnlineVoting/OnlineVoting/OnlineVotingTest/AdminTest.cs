using NUnit.Framework;
using OnlineVoting.Core;
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
    public class AdminTest
    {
        [Test]
        public void AddVoterTest()
        {
            //Arrange
            Admin admin = new Admin(0, 0, "Admin", "Admin");

            //Act
            admin.AddVoter("a", "a", 1);

            //Assert
            Assert.IsTrue(Database.Users.ContainsKey(1));
            Database.Clear();
        }

        [Test]
        public void DeleteVoterTest() 
        {
            //Arrange
            Admin admin = new Admin(0, 0, "Admin", "Admin");
            admin.AddVoter("a", "a", 1);

            //Act
            admin.DeleteVoter(1);

            //Assert
            Assert.IsFalse(Database.Users.ContainsKey(1));
            Database.Clear();
        }

        [Test]
        public void AddPartyTest()
        {
            //Arrange
            Admin admin = new Admin(0, 0, "Admin", "Admin");

            //Act
            admin.AddParty("a", "a");

            //Assert
            Assert.IsTrue(Database.Parties.ContainsKey(1));
            Database.Clear();
        }

        [Test]
        public void DeletePartyTest()
        {
            //Arrange
            Admin admin = new Admin(0, 0, "Admin", "Admin");
            admin.AddParty("a", "a");

            //Act
            admin.DeleteParty(1);

            //Assert
            Assert.IsFalse(Database.Parties.ContainsKey(1));
            Database.Clear();
        }

        [Test]
        public void EditPartyTest()
        {
            //Arrange
            Admin admin = new Admin(0, 0, "Admin", "Admin");
            admin.AddParty("a", "a");

            //Act
            admin.EditParty(1, "b", "b");

            //Assert
            Assert.IsTrue(Database.Parties[1].Name == "b" && Database.Parties[1].Location == "b");
            Database.Clear();
        }

        [Test]
        public void GetAllVotersTest()
        {
            //Arrange
            Admin admin = new Admin(0, 0, "Admin", "Admin");
            Database.Users.Add(0, admin);
            admin.AddVoter("a", "a", 1);
            admin.AddVoter("b", "b", 2);

            //Act
            string result = admin.GetAllVoters();

            //Assert
            Assert.AreEqual("ID: 1 Name: a Age: 1 Gender: a\nID: 2 Name: b Age: 2 Gender: b\n", result);
            Database.Clear();
        }

        [Test]
        public void AddDeputyTest()
        {
            //Arrange
            Admin admin = new Admin(0, 0, "Admin", "Admin");
            admin.AddParty("a", "a");

            //Act
            admin.AddDeputy("a", 1);

            //Assert
            Assert.IsTrue(Database.Parties[1].Deputies.ContainsKey(1));
            Database.Clear();
        }

        [Test]
        public void DeleteDeputyTest()
        {
            //Arrange
            Admin admin = new Admin(0, 0, "Admin", "Admin");
            admin.AddParty("a", "a");
            admin.AddDeputy("a", 1);

            //Act
            admin.DeleteDeputy(1, 1);

            //Assert
            Assert.IsFalse(Database.Parties[1].Deputies.ContainsKey(1));
            Database.Clear();
        }

        [Test]
        public void EditDeputyTest()
        {
            //Arrange
            Admin admin = new Admin(0, 0, "Admin", "Admin");
            admin.AddParty("a", "a");
            admin.AddDeputy("a", 1);

            //Act
            admin.EditDeputy(1, 1, "b");

            //Assert
            Assert.IsTrue(Database.Parties[1].Deputies[1].Name == "b");
            Database.Clear();
        }

        [Test]
        public void GetVotingResultsTest() 
        {
            //Arrange
            Admin admin = new Admin(0, 0, "Admin", "Admin");
            admin.AddParty("a", "a");
            admin.AddDeputy("a", 1);
            admin.AddParty("b", "b");
            admin.AddDeputy("a", 2);
            Voter voter = new Voter(1, 1, "a", "a");
            voter.Vote(1,1);
            voter.Vote(2,1);

            //Act
            string result = admin.GetVotingResults();

            //Assert();
            Assert.AreEqual("a have 1 Votes.\na has 1 Votes.\nb have 1 Votes.\na has 1 Votes.\n", result);
            Database.Clear();
        }

        [Test]
        public void GetVotesCountForPartyTest()
        {
            //Arrange
            Admin admin = new Admin(0, 0, "Admin", "Admin");
            admin.AddParty("a", "a");
            admin.AddDeputy("a", 1);
            Voter voter = new Voter(1, 1, "a", "a");
            voter.Vote(1, 1);

            //Act
            string result = admin.GetVotesCountForParty(1);

            //Assert();
            Assert.AreEqual("a have 1 Votes.\n", result);
            Database.Clear();
        }

        [Test]
        public void GetVotesCountForPartyPerDeputyTest()
        {
            //Arrange
            Admin admin = new Admin(0, 0, "Admin", "Admin");
            admin.AddParty("a", "a");
            admin.AddDeputy("a", 1);
            Voter voter = new Voter(1, 1, "a", "a");
            voter.Vote(1, 1);

            //Act
            string result = admin.GetVotesCountForPartyPerDeputy(1);

            //Assert();
            Assert.AreEqual("a has 1 Votes.\n", result);
            Database.Clear();
        }
    }
}
