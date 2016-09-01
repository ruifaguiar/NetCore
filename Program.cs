using System;
using NetCore.ProxyPattern;


namespace NetCore
{
    public class Program
    {
     
        public static void Main(string[] args)
        {
            ProxyExample();
          

            Console.ReadLine();
        }
        private static void ProxyExample()
        {
            IReader reader = new FileReader();
            Console.WriteLine(reader.Read());
            reader.Dispose();
        }

       
    }
}
