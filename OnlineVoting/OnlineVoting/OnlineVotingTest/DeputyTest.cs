using NUnit.Framework;
using OnlineVoting.Models.PartyModels;

namespace OnlineVotingTest
{
    [TestFixture]
    public class DeputyTest
    {
        [Test]
        public void ToStringTest()
        {
            //Arrange
            Deputy deputy = new Deputy(13, "asdf");

            //Act
            string result = deputy.ToString();

            //Assert
            Assert.AreEqual("Name: asdf ID: 13", result);
        }
    }
}