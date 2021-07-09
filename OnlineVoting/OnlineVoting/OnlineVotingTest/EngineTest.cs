using NUnit.Framework;
using OnlineVoting.Models.UserModels;
using OnlineVoting.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVotingTest
{
    [TestFixture]
    public class EngineTest
    {
        [Test]
        public void WrongCommandTest()
        {
            //Arrange
            Engine engine = new Engine();
            Admin admin = new Admin(0, 0, "Admin", "Admin");
            string command = "asd";

            //Assert
            Assert.Throws<System.Exception>(() => engine.Run(admin, command));
        }

        [Test]
        public void WrongParametersTest()
        {
            //Arrange
            Engine engine = new Engine();
            Admin admin = new Admin(0, 0, "Admin", "Admin");
            string command = "AddVoter 1 1 a";

            //Assert
            Assert.Throws<System.Exception>(() => engine.Run(admin, command));
        }
    }
}
