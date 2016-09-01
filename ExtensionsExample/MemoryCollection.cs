using System.Collections.Generic;

namespace NetCore.ExtensionsExample
{
    public class MemoryCollection : IProductCollection
    {
        public MemoryCollection()
        {
            _products = GenerateProducts();
        }

        private readonly IEnumerable<Product> _products;

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        private static IEnumerable<Product> GenerateProducts()
        {
            var list = new List<Product> { new Product("Meat"), new Product("Rice"), new Product("Beans") };
            return list;
        }
    }
}
