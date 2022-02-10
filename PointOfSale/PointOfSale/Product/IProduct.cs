using PointOfSale.PriceCalculators;

namespace PointOfSale.Product
{
    public interface IProduct
    {
        public string UnitCode { get; init; }
        public IPriceCalculator PriceCalculator { get; init; }
    }
}