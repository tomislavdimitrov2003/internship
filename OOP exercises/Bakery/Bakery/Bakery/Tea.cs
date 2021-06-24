using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery
{
    class Tea : Drink
    {
        const decimal teaPrice = 2.5M;
        public Tea(string name, int portion, decimal price, string brand)
            : base(name, portion, price, brand)
        {
            this.Price = teaPrice;
        }
    }
}
