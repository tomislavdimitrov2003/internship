using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomisheet.Models.TimesheetModels
{
    public class Row
    {
        private int id;
        private int userID;
        private int projectID;
        private string taskName;
        private DateTime startTime;
        private DateTime endTime;
        private TimeSpan duration;

        public Row(int id, int userID, int projectID, string taskName, DateTime startTime, DateTime endTime)
        {
            this.ID = id;
            this.UserID = userID;
            this.ProjectID = projectID;
            this.TaskName = taskName;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Duration = EndTime - StartTime;
        }

        public int ID { get => id; set => id = value; }
        public int ProjectID { get => projectID; set => projectID = value; }
        public string TaskName { get => taskName; set => taskName = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public TimeSpan Duration { get => duration; set => duration = value; }
        public int UserID { get => userID; set => userID = value; }

        public override string ToString()
        {
            return $"ID: {ID} ProjectID: {ProjectID} TaskName: {TaskName} StartTime: {StartTime} EndTime: {EndTime} Duration: {Duration}\n";
        }
    }
}
