using System;
using System.Collections.Generic;
using PointOfSale.Interfaces;

namespace PointOfSale.Models
{
    public class PriceCalculator : IPriceCalculator
    {
        public decimal CalculatePrice(IDictionary<string, int> products, IDictionary<string, IProduct> prices)
        {
            var total = 0.0M;

            foreach (var (productCode, count) in products)
            {
                try
                {
                    total += CalculateUnitPrice(prices[productCode], count);
                }
                catch (DivideByZeroException)
                {
                    //logging message $"Product {productCode} have no positive Volume of Discount"
                    throw;
                }
            }
            
            return total;
        }

        private static decimal CalculateUnitPrice(IProduct product, int totalVolume)
        {
            var discountTotalVolume = totalVolume / product.Discount?.Volume ?? 0;
            var singleUnitTotal = totalVolume % product.Discount?.Volume ?? totalVolume;

            return (discountTotalVolume * product.Discount?.Price ?? 0.0M) + singleUnitTotal * product.SingleUnitPrice;
        }
    }
}
