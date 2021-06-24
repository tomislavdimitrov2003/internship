using System;

namespace Bakery
{
    class Program
    {
        static void Main(string[] args)
        {
            Food food = new Food("Cake", 12, 14);
            Console.WriteLine(food.ToString());
        }
    }
}
