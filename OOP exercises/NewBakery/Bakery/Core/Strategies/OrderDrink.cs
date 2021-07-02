using Bakery.Core.Contracts;
using Bakery.Core.Strategies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Core.Strategies
{
    class OrderDrink : IStrategy
    {
        public string Execute(string[] args, IController controller)
        {
            int tableN = int.Parse(args[1]);
            string drName = args[2];
            string drinkBrand = args[3];

            string result = controller.OrderDrink(tableN, drName, drinkBrand);

            return controller.PrintMessage(printArguments);
        }
    }
}
