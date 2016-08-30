using System;

namespace NetCore.DelegatePublishSubscribe
{
    public class Client
    {
        public string NameOfClient { get; set; }

        public void PriceNotificationHandler(Product product)
        {
           Console.WriteLine($"I {NameOfClient} recieved the update for product {product.ProductName} for price of {product.Price}"); 
        }
    }
}
