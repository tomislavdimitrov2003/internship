using System.Collections.Generic;

namespace Bakery.Utilities.ProductMaps
{
    public class DrinkType
    {
    public Dictionary<string, decimal> DrinkPrice = new Dictionary<string, decimal>();

    public DrinkType()
    {
        DrinkPrice.Add("Tea", 2.5M);
        DrinkPrice.Add("Water", 1.5M);
    }
}
}
