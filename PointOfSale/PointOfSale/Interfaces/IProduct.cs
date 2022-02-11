using PointOfSale.Models;

namespace PointOfSale.Interfaces
{
    public interface IProduct
    {
        string UnitCode { get; init; }
        decimal SingleUnitPrice { get; init; }
        Discount Discount { get; init; }
    }
}