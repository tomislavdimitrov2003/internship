using Bakery.Core.Contracts;
using Bakery.Core.Strategies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Core.Strategies
{
    class OrderFood : IStrategy
    {
        public string Execute(string[] args, IController controller)
        {
            int tableNum = int.Parse(args[1]);
            string foodName = args[2];

            string result = controller.OrderFood(tableNum, foodName);

            return controller.PrintMessage(printArguments);
        }
    }
}
