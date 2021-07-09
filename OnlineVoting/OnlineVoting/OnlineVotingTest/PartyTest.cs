using NUnit.Framework;
using OnlineVoting.Models.PartyModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVotingTest
{
    [TestFixture]
    public class PartyTest
    {
        [Test]
        public void ToStringTest()
        {
            //Arrange
            Party party = new Party(4, "QWE", "zxc");

            //Act
            string result = party.ToString();

            //Assert
            Assert.AreEqual("ID: 4 Name: QWE Location: zxc", result);
        }
    }
}
