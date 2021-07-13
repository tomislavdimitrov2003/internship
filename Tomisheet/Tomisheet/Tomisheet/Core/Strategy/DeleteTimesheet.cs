using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomisheet.Models.UserModels;

namespace Tomisheet.Core.Strategy
{
    class DeleteTimesheet
    {
        public string Execute(Employee currentUser, string[] args)
        {
            int id = int.Parse(args[1]);

            currentUser.DeleteTimesheet(id);

            return "";
        }
    }
}
