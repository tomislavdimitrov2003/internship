using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Models.PartyModels
{
    public class Deputy
    {
        private string name;
        private int id;
        private int votes = 0;

        public Deputy(int id, string name)
        {
            this.Name = name;
            this.ID = id;
        }

        public string Name { get => name; set => name = value; }
        public int ID { get => id; set => id = value; }
        public int Votes { get => votes; set => votes = value; }

        public override string ToString()
        {
            return "Name: " + this.Name + " ID: " + this.ID;
        }
    }
}
