namespace Bakery.Core
{
    using Bakery.Core.Contracts;
    using Bakery.IO;
    using Bakery.IO.Contracts;
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks.Contracts;
    using Bakery.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using Bakery.Core.Strategies;
    using Bakery.Core.Strategies.Contracts;
    using Bakery.Core.Commands;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }

        public void Run()
        {
            Dictionary<string, IStrategy> strategies = new Dictionary<string, IStrategy>();
            AddFood addFood = new AddFood();
            strategies.Add("AddFood", addFood);
            AddDrink addDrink = new AddDrink();
            strategies.Add("AddDrink", addDrink);
            AddTable addTable = new AddTable();
            strategies.Add("AddTable", addTable);
            GetFreeTablesInfo getFreeTablesInfo = new GetFreeTablesInfo();
            strategies.Add("GetFreeTablesInfo", getFreeTablesInfo);
            GetTotalIncome getTotalIncome = new GetTotalIncome();
            strategies.Add("GetTotalIncome", getTotalIncome);
            LeaveTable leaveTable = new LeaveTable();
            strategies.Add("LeaveTable", leaveTable);
            OrderDrink orderDrink = new OrderDrink();
            strategies.Add("OrderDrink", orderDrink);
            OrderFood orderFood = new OrderFood();
            strategies.Add("OrderFood", orderFood);
            ReserveTable reserveTable = new ReserveTable();
            strategies.Add("ReserveTable", reserveTable);
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] arguments = input.Split();

                string command = arguments[0];

                try
                {
                    writer.WriteLine(strategies[arguments[0]].Execute(arguments, controller));
                }
                catch (ArgumentNullException ane)
                {
                    writer.WriteLine(ane.Message);
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
                input = reader.ReadLine();
            }
        }
    }
}