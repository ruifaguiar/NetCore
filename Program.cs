using System;
using NetCore.SingletonPattern;


namespace NetCore
{
    public class Program
    {
        
        public static void Main(string[] args)
        {

            SingletonExample();

            Console.ReadLine();
        }

        private static void SingletonExample()
        {
            Highlander john = Highlander.GetInstance();
            Highlander rick = Highlander.GetInstance();
            //With ReferenceEquals we can see if the variable pointers point to the same reference
            Console.WriteLine($"john is equal to rick? {ReferenceEquals(john, rick)}");

        }
       

    }
}
