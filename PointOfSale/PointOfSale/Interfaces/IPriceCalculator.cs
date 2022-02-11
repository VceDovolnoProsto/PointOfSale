using System.Collections.Generic;

namespace PointOfSale.Interfaces
{
    public interface IPriceCalculator
    {
        decimal CalculatePrice(IDictionary<string, int> products, IDictionary<string, IProduct> prices);
    }
}
