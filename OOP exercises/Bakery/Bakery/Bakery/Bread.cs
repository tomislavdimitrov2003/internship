using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery
{
    class Bread : Food
    {
        const int initialBreadPortion = 200;
        public Bread(string name, int portion, decimal price) 
            : base(name, portion, price)
        {
            this.Portion = initialBreadPortion;
        }
    }
}
