using static System.Console;

namespace ObserverPattern
{
    public class Customer : ICustomer
    {
        void ICustomer.Update(IProduct product)
        {
            WriteLine($"{product.Name} is at {product.Price}$");
        }
    }
}