using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private int horsePower;
        private double fuel;
        private double defaultFuelConsumption;
        private double fuelConsumption;

        public Vehicle(int horsePower, double fuel)
        {
            this.horsePower = horsePower;
            this.fuel = fuel;
            this.DefaultFuelConsumption = 1.25;
            this.FuelConsumption = DefaultFuelConsumption;
        }

        protected double DefaultFuelConsumption
        {
            get 
            {
                return defaultFuelConsumption;
            }
            set
            {
                defaultFuelConsumption = value;
            }
        }

        protected virtual double FuelConsumption
        {
            get
            {
                return fuelConsumption;
            }
            set
            {
                fuelConsumption = value;
            }
        }

        private double Fuel
        {
            get
            {
                return fuel;
            }
            set
            {
                fuel = value;
            }
        }

        private int HorsePower
        {
            get
            {
                return horsePower;
            }
            set
            {
                horsePower = value;
            }
        }

        public virtual void Drive(double kilometers)
        {
            Fuel = Fuel - (kilometers * FuelConsumption);
        }

        public override string ToString()
        {
            return "Horse Power: " + HorsePower + " Fuel: " + Fuel;
        }
    }
}
