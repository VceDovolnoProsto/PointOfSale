using System.Collections.Generic;
using PointOfSale.Product;

namespace PointOfSale.Stock
{
    public interface IStock
    {
        public Dictionary<string, IProduct> Items { get; }
        public void AddProduct(IProduct product);
        public void AddProducts(IEnumerable<IProduct> products);
    }
}
