using Bakery.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Core.Strategies.Contracts
{
    interface IStrategy
    {
        string Execute(string [] args, IController controller);
    }
}
