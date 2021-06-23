using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class FamilyCar : Car
    {
        public FamilyCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            this.FuelConsumption = DefaultFuelConsumption;
        }

        public override string ToString()
        {
            return "Family Car: " + base.ToString();
        }
    }
}
