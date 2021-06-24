using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            DefaultFuelConsumption = 8;
            this.FuelConsumption = DefaultFuelConsumption;
        }

        public override string ToString()
        {
            return "Race Motorcycle: " + base.ToString();
        }
    }
}
