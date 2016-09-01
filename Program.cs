using System;
using NetCore.MediatorPattern;

namespace NetCore
{
    public class Program
    {
        public delegate int AddFunction(int val1, int val2);

        public delegate void PriceUpdateHandler(Board product);
        public static void Main(string[] args)
        {
            MediatorPatternExample();
            Console.ReadLine();
        }

        private static void MediatorPatternExample()
        {
            IPart board = new Board
            {
                Price = 4.5m,
                Name = "Motherboard"
            };

            IPart cpu = new Transistor
            {
                Price = 50.1m,
                Name = "Cpu"
            };
            Client client = new Client { NameOfClient = "Rui" };
            client.SubscribePart(board);
            Client c2 = new Client { NameOfClient = "Sara" };
            client.SubscribePart(board);
            c2.SubscribePart(board);
            c2.SubscribePart(cpu);
            board.Price = 5.5m;
            cpu.Price = 10m;



        }

      

    }
}
