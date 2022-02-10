using PointOfSale.PriceCalculators;

namespace PointOfSale.Product
{
    public class Product : IProduct
    {
        public string UnitCode { get; init; }
        public IPriceCalculator PriceCalculator { get; init; }
    }
}
