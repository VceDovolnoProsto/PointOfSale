namespace PointOfSale.PriceCalculators
{
    public class WholesalePriceCalculator : IPriceCalculator
    {
        private readonly SingleUnitPriceCalculator _singleUnitCalculator;
        private readonly decimal _wholesalePrice;
        private readonly int _wholesaleSize;

        public WholesalePriceCalculator(decimal singleUnitPrice, int volumeSize, decimal wholesalePrice)
        {
            _singleUnitCalculator = new SingleUnitPriceCalculator(singleUnitPrice);
            _wholesaleSize = volumeSize;
            _wholesalePrice = wholesalePrice;
        }

        public decimal CalculatePrice(int itemsCount)
        {
            var singleUnitCount = itemsCount % _wholesaleSize;
            return (itemsCount - singleUnitCount) / _wholesaleSize * _wholesalePrice + _singleUnitCalculator.CalculatePrice(singleUnitCount);
        }
    }
}
