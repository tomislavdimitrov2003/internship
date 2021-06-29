using Bakery.Core.Contracts;
using Bakery.Core.Strategies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Core.Strategies
{
    class AddDrink : IStrategy
    {
        public string Execute(string[] args, IController controller)
        {
            string drinktype = args[1];
            string drinkName = args[2];
            int portion = int.Parse(args[3]);
            string brand = args[4];

            string result = controller.AddDrink(drinktype, drinkName, portion, brand);

            return result;
        }
    }
}
