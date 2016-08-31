using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCore.ExtensionsExample
{
    public static class ProductCollectionExtensions
    {
        public static IEnumerable<Product> GetProductByName(this IProductCollection collection, string name)
        {
            return collection.GetAll().Where(a => a.Name == name);
        }
    }
}
