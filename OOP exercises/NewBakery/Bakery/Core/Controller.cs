using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Utilities.Messages;
using Bakery.Models.Tables.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Models.BakedFoods;
using Bakery.Models.Tables;
using Bakery.Models.Drinks;


namespace Bakery.Core.Contracts
{

    public class Controller : IController
    {
        private Dictionary<int, ITable> tables = new Dictionary<int, ITable>();
        private Dictionary<string, IBakedFood> foods= new Dictionary<string, IBakedFood>();
        private Dictionary<string, IDrink> drinks = new Dictionary<string, IDrink>();
        private decimal totalIncome = 0;

        public string AddDrink(string type, string name, int portion, string brand)
        {
            decimal price = (decimal)(type == "Tea" ? DrinkType.Tea : DrinkType.Water)/100;
            Drink newDrink = new Drink(name, portion, price, brand);
            drinks.Add(name, newDrink);
            return String.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            int portion = (int)(type == "Bread" ? BakedFoodType.Bread : BakedFoodType.Cake)/100;
            BakedFood newFood = new BakedFood(name, portion, price);
            foods.Add(name, newFood);
            return String.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            decimal pricePerPerson = (decimal)(type == "InsideTable" ? TableType.InsideTable : TableType.OutsideTable)/100;
            Table newTable = new Table(tableNumber, capacity, pricePerPerson);
            tables.Add(tableNumber, newTable);
            return String.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            string info = "";
            foreach (var table in tables.Values) 
            {
                info += table.GetFreeTableInfo();
            }
            return info;
        }

        public string GetTotalIncome()
        {
            return String.Format(OutputMessages.TotalIncome, totalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            decimal bill = tables[tableNumber].GetBill();
            tables[tableNumber].Clear();
            totalIncome += bill;
            return "Table: " + tableNumber + "\nBill: " + bill;
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            if (!tables.ContainsKey(tableNumber)) 
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (!drinks.ContainsKey(drinkName)) 
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }
            IDrink order = drinks[drinkName];
            tables[tableNumber].OrderDrink(order);
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, drinkName);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            if (!tables.ContainsKey(tableNumber))
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (!foods.ContainsKey(foodName))
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }
            IBakedFood order = foods[foodName];
            tables[tableNumber].OrderFood(order);
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            bool canReserve = false;
            foreach (var table in tables.Values)
            {
                canReserve = table.Reserve(numberOfPeople);
                if (canReserve) 
                {
                    return String.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
                }
            }
            return String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
        }
    }
}
