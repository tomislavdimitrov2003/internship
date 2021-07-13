using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Core;
using Tomisheet.Models.TimesheetModels;
using Tomisheet.Models.UserModels;

namespace TomisheetTest
{
    [TestFixture]
    public class ReportTest
    {
        [Test]
        public void GetTimeSpentForPeriodTest()
        {
            //Arrange
            DateTime startTime = new DateTime(2021, 6, 15, 10, 30, 50);
            DateTime endTime = new DateTime(2021, 6, 15, 12, 40, 30);
            Row row = new Row(1, 1, 1, "rty", startTime, endTime);
            Row secondRow = new Row(2, 1, 2, "uio", startTime, endTime);
            Timesheet timesheet = new Timesheet(1, 1, "qwe");
            timesheet.Rows.Add(1, row);
            timesheet.Rows.Add(2, secondRow);
            Database.Timesheets.Add(1, timesheet);
            List<int> teamIDs = new List<int>();
            teamIDs.Add(1);
            Database.Users.Add(1, new Employee(1, "qwe", teamIDs, 1, "123"));
            List<Row> expected = new List<Row>();
            expected.Add(row);
            expected.Add(secondRow);

            //Act
            List<Row> result = Report.GetTimeSpentForPeriodReport(startTime, endTime, 1);
            Console.WriteLine(result.Count);

            //Assert
            Assert.AreEqual(expected, result);
            Database.Clear();
        }

        [Test]
        public void GetTeamTimeReportTest()
        {
            //Arrange
            DateTime startTime = new DateTime(2021, 6, 15, 10, 30, 50);
            DateTime endTime = new DateTime(2021, 6, 15, 12, 40, 30);
            Row row = new Row(1, 1, 1, "rty", startTime, endTime);
            Row secondRow = new Row(2, 1, 2, "uio", startTime, endTime);
            Timesheet timesheet = new Timesheet(1, 1, "qwe");
            timesheet.Rows.Add(1, row);
            timesheet.Rows.Add(2, secondRow);
            Database.Timesheets.Add(1, timesheet);
            List<int> teamIDs = new List<int>();
            teamIDs.Add(1);
            Database.Users.Add(1, new Employee(1, "qwe", teamIDs, 1, "123"));
            List<Row> expected = new List<Row>();
            expected.Add(row);
            expected.Add(secondRow);

            //Act
            List<Row> result = Report.GetTeamTimeReport(startTime, endTime, 1);
            Console.WriteLine(result.Count);

            //Assert
            Assert.AreEqual(expected, result);
            Database.Clear();
        }

        [Test]
        public void GetProjectTimeReportTest()
        {
            //Arrange
            DateTime startTime = new DateTime(2021, 6, 15, 10, 30, 50);
            DateTime endTime = new DateTime(2021, 6, 15, 12, 40, 30);
            Row row = new Row(1, 1, 1, "rty", startTime, endTime);
            Row secondRow = new Row(2, 1, 1, "uio", startTime, endTime);
            Timesheet timesheet = new Timesheet(1, 1, "qwe");
            timesheet.Rows.Add(1, row);
            timesheet.Rows.Add(2, secondRow);
            Database.Timesheets.Add(1, timesheet);
            List<int> teamIDs = new List<int>();
            teamIDs.Add(1);
            Database.Users.Add(1, new Employee(1, "qwe", teamIDs, 1, "123"));
            List<Row> expected = new List<Row>();
            expected.Add(row);
            expected.Add(secondRow);

            //Act
            List<Row> result = Report.GetProjectTimeReport(startTime, endTime, 1);
            Console.WriteLine(result.Count);

            //Assert
            Assert.AreEqual(expected, result);
            Database.Clear();
        }
    }
}
