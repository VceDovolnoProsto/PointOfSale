using System.Collections.Generic;

namespace PointOfSale.Basket
{
    public class Basket : IBasket
    {
        public Dictionary<string, int> Items { get; } = new Dictionary<string, int>();

        public void Add(string productCode)
        {
            Items.TryGetValue(productCode, out var currentQuantity);
            Items[productCode] = currentQuantity + 1;
        }
    }
}
