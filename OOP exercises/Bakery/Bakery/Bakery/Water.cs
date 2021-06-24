using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery
{
    class Water : Drink
    {
        const decimal waterPrice = 1.5M;

        public Water(string name, int portion, decimal price, string brand)
            : base(name, portion, price, brand)
        {
            this.Price = waterPrice;
        }
    }
}
