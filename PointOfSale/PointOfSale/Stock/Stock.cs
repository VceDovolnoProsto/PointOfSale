using System.Collections.Generic;
using PointOfSale.Product;

namespace PointOfSale.Stock
{
    public class Stock : IStock
    {
        public Dictionary<string, IProduct> Items { get; } = new Dictionary<string, IProduct>();

        public void AddProduct(IProduct product)
        {
            Items[product.UnitCode] = product;
        }

        public void AddProducts(IEnumerable<IProduct> products)
        {
            foreach (var product in products)
            {
                Items[product.UnitCode] = product;
            }
        }
    }
}
