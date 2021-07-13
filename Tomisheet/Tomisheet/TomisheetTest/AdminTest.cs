using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Core;
using Tomisheet.Models.UserModels;

namespace TomisheetTest
{
    [TestFixture]
    public class AdminTest
    {
        [Test]
        public void AddUserTest()
        {
            //Arrange
            List<int> teamIDs = new List<int>();
            teamIDs.Add(1);
            Admin admin = new Admin(2, "Admin", teamIDs, 3, "admin");

            //Act
            admin.AddUser("asd", "qwe", teamIDs, 1);

            //Assert
            Assert.IsTrue(Database.Users.ContainsKey(1));
            Database.Clear();
        }

        [Test]
        public void DeleteUserTest()
        {
            //Arrange
            List<int> teamIDs = new List<int>();
            teamIDs.Add(1);
            Admin admin = new Admin(2, "Admin", teamIDs, 3, "admin");
            admin.AddUser("asd", "qwe", teamIDs, 1);

            //Act
            admin.DeleteUser(1);

            //Assert
            Assert.IsFalse(Database.Users.ContainsKey(1));
            Database.Clear();
        }

        [Test]
        public void ModifyUserTest()
        {
            //Arrange
            List<int> teamIDs = new List<int>();
            teamIDs.Add(1);
            Admin admin = new Admin(2, "Admin", teamIDs, 3, "admin");
            admin.AddUser("asd", "qwe", teamIDs, 1);

            //Act
            admin.ModifyUserInfo(1, "fgh");

            //Assert
            Assert.AreEqual("fgh", Database.Users[1].Name);
            Database.Clear();
        }

        [Test]
        public void ChangeUserPasswordTest()
        {
            //Arrange
            List<int> teamIDs = new List<int>();
            teamIDs.Add(1);
            Admin admin = new Admin(2, "Admin", teamIDs, 3, "admin");
            admin.AddUser("asd", "qwe", teamIDs, 1);

            //Act
            admin.ChangeUserPassword(1, "fgh");

            //Assert
            Assert.AreEqual("fgh", Database.Users[1].Password);
            Database.Clear();
        }
    }
}
