using System.Collections.Generic;
using System.Linq;
using PointOfSale.Interfaces;

namespace PointOfSale
{
    public class PointOfSaleTerminal
    {
        private readonly IBasket _basket;
        private readonly IPriceList _priceList;
        private readonly IPriceCalculator _priceCalculator;

        public PointOfSaleTerminal(IBasket basket, IPriceList priceList, IPriceCalculator priceCalculator)
        {
            _basket = basket;
            _priceList = priceList;
            _priceCalculator = priceCalculator;
        }

        public void SetPricing(IEnumerable<IProduct> products)
        {
            _priceList.AddPrices(products);
        }

        public void Scan(string productCodes)
        {
            foreach (var productCode in productCodes.Select(code => code.ToString()))
            {
                _basket.AddToBasket(productCode, _priceList.Prices);
            }
        }

        public decimal CalculateTotal()
        {
            return _priceCalculator.CalculatePrice(_basket.Products, _priceList.Prices);
        }
    }
}
