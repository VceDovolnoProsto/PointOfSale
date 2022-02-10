namespace PointOfSale.PriceCalculators
{
    public interface IPriceCalculator
    {
        decimal CalculatePrice(int itemsCount);
    }
}
