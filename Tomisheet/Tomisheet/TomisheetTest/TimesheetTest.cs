using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Models.TimesheetModels;

namespace TomisheetTest
{
    [TestFixture]
    public class TimesheetTest
    {
        [Test]
        public void ToStringTest()
        {
            //Arrange
            DateTime startTime = new DateTime(2021, 6, 15, 10, 30, 50);
            DateTime endTime = new DateTime(2021, 6, 15, 12, 40, 30);
            Row row = new Row(1, 1, 1, "asd", startTime, endTime);
            Timesheet timesheet = new Timesheet(1, 1, "qwe");
            timesheet.Rows.Add(1, row);

            //Act
            string result = timesheet.ToString();

            //Assert
            Assert.AreEqual("ID: 1 UserID: 1 Name: qwe Last Modified On: " + DateTime.Now + "\nID: 1 ProjectID: 1 TaskName: asd StartTime: 6/15/2021 10:30:50 AM EndTime: 6/15/2021 12:40:30 PM Duration: 02:09:40\n", result);
        }
    }
}
