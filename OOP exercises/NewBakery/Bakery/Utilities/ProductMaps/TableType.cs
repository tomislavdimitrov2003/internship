using System.Collections.Generic;

namespace Bakery.Utilities.ProductMaps
{
    public class TableType
    {
        public Dictionary<string, decimal> PricePerPerson = new Dictionary<string, decimal>();

    public TableType()
    {
        PricePerPerson.Add("InsideTable", 2.5M);
        PricePerPerson.Add("OutsideTable", 3.5M);
    }
}
}