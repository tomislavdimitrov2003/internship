using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery
{
    class Cake : Food
    {
        const int initialCakePortion = 245;
        public Cake(string name, int portion, decimal price)
            : base(name, portion, price)
        {
            this.Portion = initialCakePortion;
        }
    }
}
