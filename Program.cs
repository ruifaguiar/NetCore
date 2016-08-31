using System;
using System.Collections.Generic;
using System.Linq;
using NetCore.ExtensionsExample;


namespace NetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InterfaceExtensions();
            EnumerableExtensionExample();

            Console.ReadLine();
        }

        private static void InterfaceExtensions()
        {

            IProductCollection collection = new MemoryCollection();
            Console.WriteLine($"Found items for Beans? {collection.GetProductByName("Beans")?.Any()}");

            //The derived class also has access to the extension because the are declared by interface
            IProductCollection romCollection = new RomMemoryCollection("Eprom");
            Console.WriteLine($"Found items for Meat? {romCollection.GetProductByName("Meat")?.Any()}");
        }

        private static void EnumerableExtensionExample()
        {
            List<string> names = new List<string>
            {
                "Rui",
                "Pedro",
                "Joao",
                "Santos"
            };
            Console.WriteLine($"Found any name named Joao? {names.GetByPredicate(a => a.Contains("Joao"))?.Any()}");
            Console.WriteLine($"Found any name named Marta? {names.GetByPredicate(a => a.Contains("Marta"))?.Any()}");
        }

    }
}
