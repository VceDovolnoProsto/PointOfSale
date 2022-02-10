using System.Collections.Generic;

namespace PointOfSale.Basket
{
    public interface IBasket
    {
        public Dictionary<string, int> Items { get; }
        public void Add(string productCode);
    }
}