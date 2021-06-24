using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery
{
    class Food
    {
        private string name;
        private int portion;
        private decimal price;

        public Food(string name, int portion, decimal price)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
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

        public override string ToString()
        {
            return Name + ": " + Portion + "g - " + Price.ToString("F");
        }
    }
}
