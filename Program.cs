using System;
using System.Collections.Generic;
using NetCore.DelegateExample;


namespace NetCore
{
    /// <summary>
    /// When you have a long running operation (IO Operation) a delegate with a callback is a good option
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            DelegateCallbackExample();
            Console.ReadLine();
        }

        private static void DelegateCallbackExample()
        {
            LongRunning longr = new LongRunning();
            longr.LongRunningMethod(DelegateCallbackPrint);
        }

        private static void DelegateCallbackPrint(int i)
        {
            Console.WriteLine(i);
        }















    }
}
