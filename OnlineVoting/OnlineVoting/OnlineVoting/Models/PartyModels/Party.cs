using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Models.PartyModels
{
    public class Party
    {
        private int id;
        private string name;
        private string location;
        private int votes = 0;
        private Dictionary<int, Deputy> deputies = new Dictionary<int, Deputy>();
        private int lastDeputyID = 0;

        public Party(int id, string name, string location)
        {
            this.ID = id;
            this.Name = name;
            this.Location = location;
        }

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Location { get => location; set => location = value; }
        public int Votes { get => votes; set => votes = value; }
        public Dictionary<int, Deputy> Deputies { get => deputies; set => deputies = value; }
        public int LastDeputyID { get => lastDeputyID; set => lastDeputyID = value; }

        public override string ToString()
        {
            return "ID: " + this.ID + " Name: " + this.Name + " Location: " + this.Location;
        }
    }
}
