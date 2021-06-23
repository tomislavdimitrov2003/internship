using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    class SportCar : Car
    {
        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            DefaultFuelConsumption = 10;
            this.FuelConsumption = DefaultFuelConsumption;
        }

        public override string ToString()
        {
            return "Sport Car: " + base.ToString();
        }
    }
}
