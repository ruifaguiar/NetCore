using System;
using NetCore.MediatorPattern;

namespace NetCore.MediatorPattern
{
    public class ProductChangeEventArgs : EventArgs
    {
        public ProductChangeEventArgs(IPart product)
        {
            Part = product;
        }
        public IPart Part { get; }
    }
}