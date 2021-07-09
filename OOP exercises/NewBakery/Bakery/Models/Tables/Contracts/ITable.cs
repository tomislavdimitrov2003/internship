namespace Bakery.Models.Tables.Contracts
{
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks.Contracts;
    using System.Collections.Generic;

    public interface ITable
    {
        int TableNumber { get; }

        int Capacity { get; }

        int NumberOfPeople { get; }

        decimal PricePerPerson { get; }

        bool IsReserved { get; }

        decimal Price { get; }

        bool Reserve(int numberOfPeople);

        void OrderFood(IBakedFood order);

        void OrderDrink(IDrink order);

        decimal GetBill();

        void Clear();

        string GetFreeTableInfo();
    }
}
