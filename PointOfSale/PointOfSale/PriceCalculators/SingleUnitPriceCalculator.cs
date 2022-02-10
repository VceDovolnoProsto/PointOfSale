namespace PointOfSale.PriceCalculators
{
    public class SingleUnitPriceCalculator : IPriceCalculator
    {
        private readonly decimal _singleUnitPrice;

        public SingleUnitPriceCalculator(decimal singleUnitPrice)
        {
            _singleUnitPrice = singleUnitPrice;
        }

        public decimal CalculatePrice(int itemsCount)
        {
            return _singleUnitPrice * itemsCount;
        }
    }
}
