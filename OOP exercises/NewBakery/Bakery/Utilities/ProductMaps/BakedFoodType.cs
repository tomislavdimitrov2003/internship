using System.Collections.Generic;

namespace Bakery.Utilities.ProductMaps
{
    public class BakedFoodType
    {
        public Dictionary<string, int> FoodPortion = new Dictionary<string, int>();

        public BakedFoodType()
        {
            FoodPortion.Add("Bread", 200);
            FoodPortion.Add("Cake", 245);
        }
    }
}
