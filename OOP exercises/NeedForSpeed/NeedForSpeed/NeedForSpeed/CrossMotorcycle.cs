using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class CrossMotorcycle : Motorcycle
    {
        public CrossMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            this.FuelConsumption = DefaultFuelConsumption;
        }

        public override string ToString()
        {
            return "Cross Motorcycle: " + base.ToString();
        }
    }
}
