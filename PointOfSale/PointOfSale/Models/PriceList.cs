using System.Collections.Generic;
using PointOfSale.Interfaces;

namespace PointOfSale.Models
{
    public class PriceList : IPriceList
    {
        public IDictionary<string, IProduct> Prices { get; } = new Dictionary<string, IProduct>();

        public void AddPrices(IEnumerable<IProduct> products)
        {
            foreach (var product in products)
            {
                Prices[product.UnitCode] = product;
            }
        }
    }
}
