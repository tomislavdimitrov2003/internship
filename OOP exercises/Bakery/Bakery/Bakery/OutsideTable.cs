using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery
{
    class OutsideTable : Table
    {
        const decimal initialPricePerPerson = 3.5M;

        public OutsideTable(int tableNumber, int capacity, decimal pricePerPerson)
            : base(tableNumber, capacity, pricePerPerson)
        {
            this.PricePerPerson = initialPricePerPerson;
        }
    }
}
