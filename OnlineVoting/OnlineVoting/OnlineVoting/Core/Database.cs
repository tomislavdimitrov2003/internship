using OnlineVoting.Models.PartyModels;
using OnlineVoting.Models.UserModels;
using OnlineVoting.Models.UserModels.BaseUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVoting.Core
{
    public static class Database
    {
        private static Dictionary<int, Party> parties = new Dictionary<int, Party>();
        private static Dictionary<int, User> users = new Dictionary<int, User>();
        private static int lastUserID = 0;
        private static int lastPartyID = 0;

        public static Dictionary<int, Party> Parties { get => parties; set => parties = value; }
        public static Dictionary<int, User> Users { get => users; set => users = value; }
        public static int LastUserID { get => lastUserID; set => lastUserID = value; }
        public static int LastPartyID { get => lastPartyID; set => lastPartyID = value; }

        public static void Clear() 
        {
            Parties.Clear();
            Users.Clear();
            LastPartyID = 0;
            LastUserID = 0;
        }
    }
}
