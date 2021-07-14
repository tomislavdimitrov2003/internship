using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomisheet.Models.TimesheetModels
{
    public class Timesheet
    {
        private int id;
        private int userID;
        private string timesheetName;
        private DateTime lastModifiedOn;
        private Dictionary<int, Row> rows = new Dictionary<int, Row>();
        private int lastRowID = 0;

        public Timesheet(int id, int userID, string timesheetName)
        {
            this.ID = id;
            this.UserID = userID;
            this.TimesheetName = timesheetName;
            this.LastModifiedOn = DateTime.Now;
        }

        public int ID { get => id; set => id = value; }
        public int UserID { get => userID; set => userID = value; }
        public string TimesheetName { get => timesheetName; set => timesheetName = value; }
        public DateTime LastModifiedOn { get => lastModifiedOn; set => lastModifiedOn = value; }
        public int LastRowID { get => lastRowID; set => lastRowID = value; }
        public Dictionary<int, Row> Rows { get => rows; set => rows = value; }

        public override string ToString()
        {
            string result = $"ID: {ID} UserID: {UserID} Name: {TimesheetName} Last Modified On: {LastModifiedOn}\n";
            foreach (Row row in rows.Values)
            {
                result += row.ToString();
            }
            return result;
        }
    }
}
