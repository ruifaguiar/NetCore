using System.Collections.Generic;

namespace NetCore.ExtensionsExample
{
    public interface IProductCollection
    {
        IEnumerable<Product> GetAll();

    }
}
