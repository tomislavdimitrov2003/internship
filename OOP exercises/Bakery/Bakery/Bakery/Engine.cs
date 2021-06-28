using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery
{
    class Engine
    {
        void ReadCommands() 
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] line = input.Split(' ');

                string command = line[0];

                string result = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "AddFood":
                            string type = line[1];
                            string name = line[2];
                            decimal price = decimal.Parse(line[3]);

                            result = controller.AddFood(type, name, price);
                            break;

                        case "AddDrink":
                            string drinktype = line[1];
                            string drinkName = line[2];
                            int portion = int.Parse(line[3]);
                            string brand = line[4];

                            result = controller.AddDrink(drinktype, drinkName, portion, brand);
                            break;

                        case "AddTable":
                            string tableType = line[1];
                            int tableNumber = int.Parse(line[2]);
                            int capacity = int.Parse(line[3]);

                            result = controller.AddTable(tableType, tableNumber, capacity);
                            break;

                        case "ReserveTable":
                            int numberOfPeople = int.Parse(line[1]);

                            result = controller.ReserveTable(numberOfPeople);
                            break;

                        case "OrderFood":
                            int tableNum = int.Parse(line[1]);
                            string foodName = line[2];

                            result = controller.OrderFood(tableNum, foodName);
                            break;

                        case "OrderDrink":
                            int tableN = int.Parse(line[1]);
                            string drName = line[2];
                            string drinkBrand = line[3];

                            result = controller.OrderDrink(tableN, drName, drinkBrand);
                            break;

                        case "LeaveTable":
                            int leftTableNum = int.Parse(line[1]);

                            result = controller.LeaveTable(leftTableNum);
                            break;

                        case "GetFreeTablesInfo":
                            result = controller.GetFreeTablesInfo();
                            break;

                        case "GetTotalIncome":
                            result = controller.GetTotalIncome();
                            break;
                    }

                    writer.WriteLine(result);
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
