using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Drinks.Contracts
{
    class Drink : IDrink
    {
        private string name;
        private int portion;
        private decimal price;
        private string brand;

        public Drink(string name, int portion, decimal price, string brand)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
            this.Brand = brand;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;

                if (String.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }
            }
        }

        public int Portion
        {
            get
            {
                return portion;
            }
            set
            {
                portion = value;

                if (portion <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPortion);
                }
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;

                if (price <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }
            }
        }

        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                brand = value;

                if (String.IsNullOrWhiteSpace(brand))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBrand);
                }
            }
        }

        public override string ToString()
        {
            return Name + " " + Brand + " - " + Portion + "ml - " + Price.ToString("F");
        }
    }
}
