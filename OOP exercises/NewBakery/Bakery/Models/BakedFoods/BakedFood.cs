using Bakery.Models.BakedFoods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Utilities.Messages;

namespace Bakery.Models.BakedFoods
{
    class BakedFood : IBakedFood
    {
        private string name;
        private int portion;
        private decimal price;

        public BakedFood(string name, int portion, decimal price)
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

        public override string ToString()
        {
            return Name + ": " + Portion + "g - " + Price.ToString("F");
        }
    }
}
