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
    public class ManagerTest
    {
        [Test]
        public void GetTeamTimeReportTest()
        {
            //Arrange
            List<int> teamIDs = new List<int>();
            teamIDs.Add(1);
            Employee employee = new Employee(1, "asd", teamIDs, 1, "qwe");
            Database.Users.Add(1, employee);
            employee.CreateTimesheet("zxc");
            DateTime startTime = new DateTime(2021, 6, 15, 10, 30, 50);
            DateTime endTime = new DateTime(2021, 6, 15, 12, 40, 30);
            employee.CreateTimesheetRecord(1, 1, "rty", startTime, endTime);
            employee.CreateTimesheetRecord(1, 2, "uio", startTime, endTime);
            Manager manager = new Manager(2, "vbn", teamIDs, 2, "fgh");

            //Act
            string result = manager.GetTeamTimeReport(startTime, endTime, "Task", 1);

            //Assert
            Assert.AreEqual("ID: 1 ProjectID: 1 TaskName: rty StartTime: 6/15/2021 10:30:50 AM EndTime: 6/15/2021 12:40:30 PM Duration: 02:09:40\nID: 2 ProjectID: 2 TaskName: uio StartTime: 6/15/2021 10:30:50 AM EndTime: 6/15/2021 12:40:30 PM Duration: 02:09:40\n", result);
            Database.Clear();
        }

        [Test]
        public void GetProjectTimeReportTest()
        {
            //Arrange
            List<int> teamIDs = new List<int>();
            teamIDs.Add(1);
            Employee employee = new Employee(1, "asd", teamIDs, 1, "qwe");
            Database.Users.Add(1, employee);
            employee.CreateTimesheet("zxc");
            DateTime startTime = new DateTime(2021, 6, 15, 10, 30, 50);
            DateTime endTime = new DateTime(2021, 6, 15, 12, 40, 30);
            employee.CreateTimesheetRecord(1, 1, "rty", startTime, endTime);
            employee.CreateTimesheetRecord(1, 1, "uio", startTime, endTime);
            Manager manager = new Manager(2, "vbn", teamIDs, 2, "fgh");

            //Act
            string result = manager.GetProjectTimeReport(startTime, endTime, "Task", 1);

            //Assert
            Assert.AreEqual("ID: 1 ProjectID: 1 TaskName: rty StartTime: 6/15/2021 10:30:50 AM EndTime: 6/15/2021 12:40:30 PM Duration: 02:09:40\nID: 2 ProjectID: 1 TaskName: uio StartTime: 6/15/2021 10:30:50 AM EndTime: 6/15/2021 12:40:30 PM Duration: 02:09:40\n", result);
            Database.Clear();
        }
    }
}
