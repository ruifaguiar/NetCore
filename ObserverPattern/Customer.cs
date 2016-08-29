using System;


namespace NetCore.ObserverPattern
{
    public class Customer : ICustomer
    {
        void ICustomer.Update(IProduct product)
        {
            Console.WriteLine($"{product.Name} is at {product.Price}$");
        }
    }
}