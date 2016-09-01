using System;
using NetCore.ObserverPattern;


namespace NetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            ObserverPattern();

            Console.ReadLine();
        }
      
        private static void ObserverPattern()
        {
            var component = new Cpu(150);
            var ramProduct = new Ram(75);
            ICustomer cust1 = new Customer();
            ICustomer cust2 = new Customer();
            component.AddFollower(cust1);
            ramProduct.AddFollower(cust2);

            component.Price = 100;
            ramProduct.Price = 25;

        }

    }
}
