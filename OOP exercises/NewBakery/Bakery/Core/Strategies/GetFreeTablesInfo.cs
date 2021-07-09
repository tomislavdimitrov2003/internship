using Bakery.Core.Contracts;
using Bakery.Core.Strategies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Core.Strategies
{
    class GetFreeTablesInfo : IStrategy
    {
        public string Execute(string[] args, IController controller)
        {
            string result = controller.GetFreeTablesInfo();

            return result;
        }
    }
}
