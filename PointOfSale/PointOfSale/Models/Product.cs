using PointOfSale.Interfaces;

namespace PointOfSale.Models
{
    public class Product : IProduct
    {
        public string UnitCode { get; init; }
        public decimal SingleUnitPrice { get; init; }
        public Discount Discount { get; init; }
    }
}
