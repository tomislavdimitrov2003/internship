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
    public class EmployeeTest
    {
        [Test]
        public void CreateTimesheetTest()
        {
            //Arrange
            List<int> teamIDs = new List<int>();
            teamIDs.Add(1);
            Employee employee = new Employee(1, "asd", teamIDs, 1, "qwe");

            //Act
            employee.CreateTimesheet("zxc");

            //Assert
            Assert.IsTrue(Database.Timesheets.ContainsKey(1));
            Database.Clear();
        }

        [Test]
        public void DeleteTimesheetTest()
        {
            //Arrange
            List<int> teamIDs = new List<int>();
            teamIDs.Add(1);
            Employee employee = new Employee(1, "asd", teamIDs, 1, "qwe");
            employee.CreateTimesheet("zxc");

            //Act
            employee.DeleteTimesheet(1);

            //Assert
            Assert.IsFalse(Database.Timesheets.ContainsKey(1));
            Database.Clear();
        }

        [Test]
        public void CreateTimesheetRecordTest()
        {
            //Arrange
            List<int> teamIDs = new List<int>();
            teamIDs.Add(1);
            Employee employee = new Employee(1, "asd", teamIDs, 1, "qwe");
            employee.CreateTimesheet("zxc");
            DateTime startTime = new DateTime(2021, 6, 15, 10, 30, 50);
            DateTime endTime = new DateTime(2021, 6, 15, 12, 40, 30);

            //Act
            employee.CreateTimesheetRecord(1, 1, "rty", startTime, endTime);

            //Assert
            Assert.IsTrue(Database.Timesheets[1].Rows.ContainsKey(1));
            Database.Clear();
        }

        [Test]
        public void DeleteTimesheetRecordTest()
        {
            //Arrange
            List<int> teamIDs = new List<int>();
            teamIDs.Add(1);
            Employee employee = new Employee(1, "asd", teamIDs, 1, "qwe");
            employee.CreateTimesheet("zxc");
            DateTime startTime = new DateTime(2021, 6, 15, 10, 30, 50);
            DateTime endTime = new DateTime(2021, 6, 15, 12, 40, 30);
            employee.CreateTimesheetRecord(1, 1, "rty", startTime, endTime);

            //Act
            employee.DeleteTimesheetRecord(1, 1);

            //Assert
            Assert.IsFalse(Database.Timesheets[1].Rows.ContainsKey(1));
            Database.Clear();
        }

        [Test]
        public void EditTimesheetRecordTest()
        {
            //Arrange
            List<int> teamIDs = new List<int>();
            teamIDs.Add(1);
            Employee employee = new Employee(1, "asd", teamIDs, 1, "qwe");
            employee.CreateTimesheet("zxc");
            DateTime startTime = new DateTime(2021, 6, 15, 10, 30, 50);
            DateTime endTime = new DateTime(2021, 6, 15, 12, 40, 30);
            employee.CreateTimesheetRecord(1, 1, "rty", startTime, endTime);

            //Act
            employee.EditTimesheetRecord(1, 1, 2, "uio", startTime, endTime);

            //Assert
            Assert.AreEqual(Database.Timesheets[1].Rows[1].TaskName, "uio");
            Database.Clear();
        }

        [Test]
        public void GetTimeSpentForPeriodTest()
        {
            //Arrange
            List<int> teamIDs = new List<int>();
            teamIDs.Add(1);
            Employee employee = new Employee(1, "asd", teamIDs, 1, "qwe");
            employee.CreateTimesheet("zxc");
            DateTime startTime = new DateTime(2021, 6, 15, 10, 30, 50);
            DateTime endTime = new DateTime(2021, 6, 15, 12, 40, 30);
            employee.CreateTimesheetRecord(1, 1, "rty", startTime, endTime);
            employee.CreateTimesheetRecord(1, 2, "uio", startTime, endTime);

            //Act
            string result = employee.GetTimeSpentForPeriodReport(startTime, endTime, "Task");

            //Assert
            Assert.AreEqual("ID: 1 ProjectID: 1 TaskName: rty StartTime: 6/15/2021 10:30:50 AM EndTime: 6/15/2021 12:40:30 PM Duration: 02:09:40\nID: 2 ProjectID: 2 TaskName: uio StartTime: 6/15/2021 10:30:50 AM EndTime: 6/15/2021 12:40:30 PM Duration: 02:09:40\n", result);
            Database.Clear();
        }
    }
}
