using System.Collections.Generic;

namespace PointOfSale.Interfaces
{
    public interface IPriceList
    {
        IDictionary<string, IProduct> Prices { get; }
        void AddPrices(IEnumerable<IProduct> products);
    }
}
