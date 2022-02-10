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
        private readonly IStock _stockInfo = new Stock.Stock();

        public void SetPricing(IEnumerable<IProduct> products)
        {
            _stockInfo.AddProducts(products);
        }

        public void Scan(string productCodes)
        {
            foreach (var productCode in productCodes.Select(code => code.ToString()))
            {
                if (!_stockInfo.Items.ContainsKey(productCode))
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
                total += _stockInfo.Items[productCode].PriceCalculator.CalculatePrice(count);
            }

            return total;
        }
    }
}
