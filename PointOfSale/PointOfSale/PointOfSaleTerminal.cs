using System;
using System.Collections.Generic;
using System.Linq;
using PointOfSale.Basket;
using PointOfSale.Product;
using PointOfSale.Stock;

namespace PointOfSale
{
    public class PointOfSaleTerminal
    {
        private readonly IBasket _basket = new Basket.Basket();
        private readonly IStock _stock = new Stock.Stock();

        public void SetPricing(IEnumerable<IProduct> products)
        {
            _stock.AddProducts(products);
        }

        public void Scan(string productCodes)
        {
            foreach (var productCode in productCodes.Select(code => code.ToString()))
            {
                if (!_stock.Items.ContainsKey(productCode))
                {
                    throw new ArgumentException($"There is no such product {productCode} in stock");
                }

                _basket.Add(productCode);
            }
        }

        public decimal CalculateTotal()
        {
            var total = 0.0M;

            foreach (var (productCode, count) in _basket.Items)
            {
                total += _stock.Items[productCode].PriceCalculator.CalculatePrice(count);
            }

            return total;
        }
    }
}
