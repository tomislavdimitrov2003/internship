using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Tables
{
    class Table : ITable
    {
        private List<IBakedFood> foodOrders = new List<IBakedFood>();
        private List<IDrink> drinkOrders = new List<IDrink>();
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved = false;
        private bool isInside;
        private decimal price;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }

        public List<IBakedFood> FoodOrders { get => foodOrders; set => foodOrders = value; }
        public List<IDrink> DrinkOrders { get => drinkOrders; set => drinkOrders = value; }
        public int TableNumber { get => tableNumber; set => tableNumber = value; }
        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                capacity = value;

                if (capacity <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
            }
        }
        public int NumberOfPeople
        {
            get
            {
                return numberOfPeople;
            }
            set
            {
                numberOfPeople = value;

                if (numberOfPeople <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
            }
        }
        public decimal PricePerPerson { get => pricePerPerson; set => pricePerPerson = value; }
        public bool IsReserved { get => isReserved; set => isReserved = value; }
        public bool IsInside { get => isInside; set => isInside = value; }
        public decimal Price { get => price; set => price = value; }

        public bool Reserve(int numberOfPeople)
        {
            bool canFitOnTable = numberOfPeople <= Capacity;
            bool canReserve = false;
            if (!IsReserved && canFitOnTable)
            {
                IsReserved = true;
                canReserve = true;
                NumberOfPeople = numberOfPeople;
            }
            return canReserve;
        }

        public void OrderFood(IBakedFood order)
        {
            FoodOrders.Add(order);
        }

        public void OrderDrink(IDrink order)
        {
            DrinkOrders.Add(order);
        }

        public decimal GetBill()
        {
            decimal bill = NumberOfPeople * PricePerPerson;

            foreach (var food in FoodOrders)
            {
                bill += food.Price;
            }

            foreach (var drink in DrinkOrders)
            {
                bill += drink.Price;
            }
            return bill;
        }

        public void Clear()
        {
            FoodOrders.Clear();
            DrinkOrders.Clear();
            IsReserved = false;
        }

        public string GetFreeTableInfo()
        {
            string info = null;
            if (!IsReserved)
            {
                info = "Table: " + TableNumber + "\nType: " + (IsInside ? "Inside Table" : "Outside Table") + "\nCapacity: " + Capacity + "\nPrice Per Person: " + PricePerPerson + "\n";
            }
            return info;
        }
    }
}
