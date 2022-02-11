using System.Collections.Generic;

namespace PointOfSale.Interfaces
{
    public interface IBasket
    {
        IDictionary<string, int> Products { get; }
        void AddToBasket(string productCode, IDictionary<string, IProduct> prices);
    }
}