using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery
{
    class Table
    {
        private List<Food> foodOrders = new List<Food>();
        private List<Drink> drinkOrders = new List<Drink>();
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;
        private bool isInside;

        public Table(int tableNumber, int capacity, decimal pricePerPerson) 
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }

        internal List<Food> FoodOrders { get => foodOrders; set => foodOrders = value; }
        internal List<Drink> DrinkOrders { get => drinkOrders; set => drinkOrders = value; }
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
                    throw new ArgumentException("Capacity cannot be less or equal to zero!");
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
                    throw new ArgumentException("Cannot place zero or less people!");
                }
            }
        }
        public decimal PricePerPerson { get => pricePerPerson; set => pricePerPerson = value; }
        public bool IsReserved { get => isReserved; set => isReserved = value; }
        public bool IsInside { get => isInside; set => isInside = value; }

        public void Reserve(int numberOfPeople)
        {
            bool canFitOnTable = numberOfPeople <= Capacity;
            if (!IsReserved && canFitOnTable)
            {
                IsReserved = true;
            }
        }

        public void OrderFood(Food order)
        {
            FoodOrders.Add(order);
        }

        public void OrderDrink(Drink order)
        {
            DrinkOrders.Add(order);
        }

        public decimal GetBill()
        {
            decimal bill = 0;

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

        public void GetFreeTableInfo()
        {
            if (!IsReserved)
            {
                Console.WriteLine("Table: " + TableNumber);
                Console.WriteLine("Type: " + (IsInside ? "Inside Table" : "Outside Table"));
                Console.WriteLine("Capacity: " + Capacity);
                Console.WriteLine("Price Per Person: " + PricePerPerson);
            }
        }
    }
}
