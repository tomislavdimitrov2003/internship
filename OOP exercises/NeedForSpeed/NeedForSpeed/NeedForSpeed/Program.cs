using System;

namespace NeedForSpeed
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicles = new Vehicle[4];
            vehicles[0] = new FamilyCar(70, 200.0);
            vehicles[1] = new SportCar(200, 110.2);
            vehicles[2] = new CrossMotorcycle(50, 50.0);
            vehicles[3] = new RaceMotorcycle(100, 50.0);

            foreach (var vehicle in vehicles)
            {
                vehicle.Drive(3.0);
                Console.WriteLine(vehicle.ToString());
            }
        }

    }
}
