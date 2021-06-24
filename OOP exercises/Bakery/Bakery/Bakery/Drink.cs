using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery
{
    class Drink
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
                    throw new ArgumentException("Name cannot be null or whitespace!");
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
                    throw new ArgumentException("Portion cannot be less or equal to zero!");
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
                    throw new ArgumentException("Price cannot be less or equal to zero!");
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
                    throw new ArgumentException("Brand cannot be null or whitespace!");
                }
            }
        }

        public override string ToString()
        {
            return Name + " " + Brand + " - " + Portion + "ml - " + Price.ToString("F");
        }
    }
}
