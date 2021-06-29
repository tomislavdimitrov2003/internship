using Bakery.Models.BakedFoods;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using Bakery.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bakery.Core.Strategies.Contracts;
using Bakery.Core.Contracts;

namespace Bakery.Core.Commands
{
    class AddFood : IStrategy
    {
        public string Execute(string[] args, IController controller)
        {
            string type = args[1];
            string name = args[2];
            decimal price = decimal.Parse(args[3]);

            string result = controller.AddFood(type, name, price);

            return result;
        }
    }
}
