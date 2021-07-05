using Bakery.Core.Contracts;
using Bakery.Core.Strategies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Core.Strategies
{
    class LeaveTable : IStrategy
    {
        public string Execute(string[] args, IController controller)
        {
            int leftTableNum = int.Parse(args[1]);

            string result = controller.LeaveTable(leftTableNum);

            return result;
        }
    }
}
