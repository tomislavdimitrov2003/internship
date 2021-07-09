using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Utilities.Messages;
using Bakery.Models.Tables.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.ProductMaps;
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
        DrinkType drinkType = new DrinkType();
        BakedFoodType foodType = new BakedFoodType();
        TableType tableType = new TableType();

        public string AddDrink(string type, string name, int portion, string brand)
        {
            decimal price = drinkType.DrinkPrice[type];
            Drink newDrink = new Drink(name, portion, price, brand);
            drinks.Add(name, newDrink);

            return String.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            int portion = foodType.FoodPortion[type];
            BakedFood newFood = new BakedFood(name, portion, price);
            foods.Add(name, newFood);

            return String.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            decimal pricePerPerson = tableType.PricePerPerson[type];
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
            string result = null;

            if (!tables.ContainsKey(tableNumber)) 
            {
                result = String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (!drinks.ContainsKey(drinkName)) 
            {
                result = String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            if (result == null)
            {
                IDrink order = drinks[drinkName];
                tables[tableNumber].OrderDrink(order);

                result = String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, drinkName);
            }

            return result;
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            string result = null;

            if (!tables.ContainsKey(tableNumber))
            {
                result = String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (!foods.ContainsKey(foodName))
            {
                result = String.Format(OutputMessages.NonExistentFood, foodName);
            }

            if (result == null) 
            {
                IBakedFood order = foods[foodName];
                tables[tableNumber].OrderFood(order);

                result = String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
            }
            return result;
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
