using System;
using System.Collections.Generic;
using PointOfSale.Interfaces;

namespace PointOfSale.Models
{
    public class Basket : IBasket
    {
        public IDictionary<string, int> Products { get; } = new Dictionary<string, int>();

        public void AddToBasket(string productCode, IDictionary<string, IProduct> prices)
        {
            if (prices is null)
            {
                return;
            }
            if (!prices.ContainsKey(productCode))
            {
                throw new ArgumentException($"There is no such product {productCode} in stock");
            }

            Products.TryGetValue(productCode, out var currentQuantity);
            Products[productCode] = currentQuantity + 1;
        }
    }
}
