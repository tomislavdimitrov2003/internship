using Bakery.Core.Contracts;
using Bakery.Core.Strategies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Core.Strategies
{
    class AddTable : IStrategy
    {
        public string Execute(string[] args, IController controller)
        {
            string tableType = args[1];
            int tableNumber = int.Parse(args[2]);
            int capacity = int.Parse(args[3]);

            string result = controller.AddTable(tableType, tableNumber, capacity);

            return controller.PrintMessage(printArguments);
        }
    }
}
