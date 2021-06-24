using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery
{
    class InsideTable : Table
    {
        const decimal initialPricePerPerson = 2.5M;

        public InsideTable(int tableNumber, int capacity, decimal pricePerPerson)
            : base(tableNumber, capacity, pricePerPerson)
        {
            this.PricePerPerson = initialPricePerPerson;
        }
    }
}
