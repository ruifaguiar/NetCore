using System;
using System.Collections.Generic;
using System.Linq;
using NetCore.BuilderPattern;
using static NetCore.BuilderPattern.CellPhone;
using NetCore.DelegateExample;
using NetCore.DisposablePattern;
using NetCore.ExtensionsExample;
using NetCore.FactoryPattern;
using NetCore.MediatorPattern;
using NetCore.MediatorPatternDelegate;
using NetCore.ObserverPattern;
using NetCore.PrototypePattern;
using NetCore.ProxyPattern;
using NetCore.SingletonPattern;
using NetCore.StrategyPattern;
using NetCore.ConcurrentCollections;

namespace NetCore
{
    public class Program
    {
        public delegate int AddFunction(int val1, int val2);

        public delegate void PriceUpdateHandler(Board product);
        public static void Main(string[] args)
        {
            //ProxyExample();
            //FactoryExample();
            //SingletonExample();
            //SingletonThreadSafeExample();
            //DelegateExample();
            //DelegateCallbackExample();
            //StrategyPattern(DayOfWeek.Monday);
            //StrategyPattern(DayOfWeek.Sunday);
            //StrategyPattern(DayOfWeek.Thursday);
            //ObserverPattern();
            //PrototypePattern();
            //MediatorPatternExample();
            //MediatorPatternDelegate();
            //InterfaceExtensions();
            //EnumerableExtensionExample();
            //BuilderPatternExample();
            //DisposablePatternExample();
            ConcurrentCollectionsExample();

            Console.ReadLine();
        }
        private static void ProxyExample()
        {
            IReader reader = new FileReader();
            Console.WriteLine(reader.Read());
            reader.Dispose();
        }

        private static void FactoryExample()
        {
            IAnimalFactory factory = AnimalFactory.CreateFactory();
            IAnimal carnivore = factory.CreateAnimal(AnimalType.Carnivore);
            IAnimal herbivore = factory.CreateAnimal(AnimalType.Herbivore);

            Console.WriteLine("I am a {0}, i sleep for {1} hours and like to eat {2}", carnivore.GetType().Name, carnivore.Sleep(), carnivore.Eat());
            Console.WriteLine("I am a {0}, i sleep for {1} hours and like to eat {2}", herbivore.GetType().Name, herbivore.Sleep(), herbivore.Eat());
        }

        private static void SingletonExample()
        {
            Highlander john = Highlander.GetInstance();
            Highlander rick = Highlander.GetInstance();

            Console.WriteLine($"john is equal to rick? {ReferenceEquals(john, rick)}");

        }

        private static void SingletonThreadSafeExample()
        {
            //here we should try and make two thread create an instance at the same time.
            HighlanderThreadSafe john = HighlanderThreadSafe.GetInstance();
            HighlanderThreadSafe rick = HighlanderThreadSafe.GetInstance();

            Console.WriteLine($"john is equal to rick? {ReferenceEquals(john, rick)}");
            HighlanderThreadSafeSimpler simpleJohn = HighlanderThreadSafeSimpler.Instance;
            HighlanderThreadSafeSimpler simpleRick = HighlanderThreadSafeSimpler.Instance;
            Console.WriteLine($"john is equal to rick? {ReferenceEquals(simpleJohn, simpleRick)}");

        }
        private static void DelegateExample()
        {
            Calculator calc = new Calculator();

            AddFunction func = calc.Add;
            Console.WriteLine(func.Invoke(1, 2));
        }
        private static void DelegateCallbackExample()
        {
            LongRunning longr = new LongRunning();
            longr.LongRunningMethod(DelegateCallbackPrint);
        }

        private static void DelegateCallbackPrint(string i)
        {
            Console.WriteLine(i);
        }

        private static void StrategyPattern(DayOfWeek dayOfWeek)
        {
            IDiscountStrategy discountStrategy;
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    {
                        discountStrategy = new HighDiscountStrategy();
                        break;
                    }
                case DayOfWeek.Thursday:
                    {
                        discountStrategy = new LowDiscountStrategy();
                        break;
                    }
                default:
                    {
                        discountStrategy = new NoDiscountStrategy();
                        break;
                    }
            }


            var mall = new ShoppingMall(discountStrategy);
            mall.CustomerName = "Raquel";
            mall.BillAmount = 400;

            var discount = (double)mall.GetFinalBill() / mall.BillAmount;

            Console.WriteLine($"The Customer {mall.CustomerName} is bought {mall.BillAmount}€ and got a discount of {100 - discount * 100}%");
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

        private static void PrototypePattern()
        {
            var computer = new Computer
            {
                AmountOfCores = 4,
                AmountOfRam = 32,
                CpuFrequency = 3.4m,
                DriveType = "ssd",
                Gpu = new GraphicsCard()
                {
                    AmountOfRam = 16,
                    GpuFrequency = 1.4m
                }
            };

            var computer2 = (Computer)computer.Clone();
            Console.WriteLine($"Are both computer the same reference? {ReferenceEquals(computer, computer2)}");

            Console.WriteLine($"Computer 1 has {computer.AmountOfCores} cores and computer 2 has {computer2.AmountOfCores}");
            Console.WriteLine($"Computer 1 has {computer.AmountOfRam} GB of Ram and computer 2 has {computer2.AmountOfRam}");
            Console.WriteLine($"Computer 1 cores have {computer.CpuFrequency}  and computer 2 have {computer2.CpuFrequency}");
            Console.WriteLine($"Computer 1 drive is {computer.DriveType} and computer 2 has {computer2.DriveType}");
            Console.WriteLine($"Are both drives(string) pointing to the same reference? { ReferenceEquals(computer.DriveType, computer2.DriveType)}");
            Console.WriteLine($"Are both Gpu's(Class) pointing to the same reference? { ReferenceEquals(computer.Gpu, computer2.Gpu)}");
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

        private static void MediatorPatternDelegate()
        {
            Job gardner = new Job
            {
                Title = "Gardner",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(1)
            };
            Employee john = new Employee { Name = "Peter" };
            john.Subscribe();
            Employee sara = new Employee { Name = "Raquel" };
            sara.Subscribe();
            gardner.Title = "Mr. Gardner";

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

        private static void BuilderPatternExample()
        {
            CellPhoneBuilder builder = new CellPhoneBuilder
            {
                Cpu = "i7",
                Memory = 16,
                MemoryCapacity = 64,
                MicroSdSlot = null,
                ScreenType = "FHD"
            };
            CellPhone cellPhone = builder.Build();
            Console.WriteLine(cellPhone);

        }

        private static void DisposablePatternExample()
        {
            ClassThatNeedsDisposable yeh = new ClassThatNeedsDisposable();
            yeh.Dispose();
        }

        private static void ConcurrentCollectionsExample()
        {
            CDictionary stock = new CDictionary();
            int stockValue;

            //Try add
            var result = stock.TryAdd("Simpsons", 5);
            Console.WriteLine($"Tried to add 5 Simpsons tshirts with result:{result}");
            Console.WriteLine($"Add the same tshirt again");
            result = stock.TryAdd("Simpsons", 2);
            Console.WriteLine($"Tried to add 2 Simpsons tshirts with result:{result}");

            //Try Update
            result = stock.TryUpdate("Simpsons", 5, 6);
            Console.WriteLine($"Tried to update Simpsons tshirts (5 of stock), with a new value of 6 with result {result}");
            result = stock.TryUpdate("Simpsons", 7, 6);
            Console.WriteLine($"Tried to update Simpsons tshirts (5 of stock) sending 7 instead, with a new value of 6 with result {result}");

            //TryGet

            result = stock.TryGet("Simpsons", out stockValue);
            Console.WriteLine($"Get value for simpsons occured with result {result} and the value is {stockValue}");

            //Add or Update -> try to update the value, if key it's not present add it
            var updatedStock = stock.AddOrUpdate("Simpsons", 3);
            Console.WriteLine($"Tried to increment Simpsons tshirts (5 of stock) with a new value of {updatedStock}");
            updatedStock = stock.AddOrUpdate("Family Guy", 10);
            Console.WriteLine($"Tried to increment Simpsons tshirts (5 of stock) with a new value of {updatedStock}");

            //Get or Add -> try and get the value. if key not present add it

            stockValue = stock.GetOrAdd("Family Guy", 0);
            Console.WriteLine($"Get the value of {stockValue} for tshirt Family Guy");
            //Try Remove
            result = stock.TryRemove("Simpsons", out stockValue);
            Console.WriteLine($"Tried to remove remove Simpsons tshirts wich had {stockValue} of stock with result {result}");

            result = stock.TryRemove("Simpsons", out stockValue);
            Console.WriteLine($"Tried to remove remove Simpsons tshirts wich had {stockValue} of stock with result {result}");


            //Concurrent Queue
            CQueue queue = new CQueue();
            queue.Enqueue("Simpsons");
            queue.Enqueue("FamilyGuy");
            queue.Enqueue("StarWars");

            string shirt;
            result = queue.TryPeek(out shirt);
            if (result)
                Console.WriteLine($"The item at the front of the queue is {shirt}");
            else
                Console.WriteLine($"Error peeking. Pervert?");

            result = queue.TryDequeue(out shirt);

            if (result)
                Console.WriteLine($"The item dequeued is {shirt}");
            else
                Console.WriteLine($"Error peeking. Pervert?");

            result = queue.TryPeek(out shirt);
            if (result)
                Console.WriteLine($"The item at the front of the queue (after dequeue) is {shirt}");
            else
                Console.WriteLine($"Error peeking. Pervert?");


            //Concurrent Stack

            CStack stack = new CStack();
            stack.Push("Simpsons");
            stack.Push("FamilyGuy");
            stack.Push("StarWars");

            
            result = stack.TryPeek(out shirt);
            if (result)
                Console.WriteLine($"The item at the Top of the stack is {shirt}");
            else
                Console.WriteLine($"Error peeking. Pervert?");

            result = stack.TryPop(out shirt);

            if (result)
                Console.WriteLine($"The item poped is {shirt}");
            else
                Console.WriteLine($"Error peeking. Pervert?");

            result = stack.TryPeek(out shirt);
            if (result)
                Console.WriteLine($"The item at the Top of the stack (after Pop) is {shirt}");
            else
                Console.WriteLine($"Error peeking. Pervert?");


            //ConcurrentBag No garanties for the order of put and take. In single thread it tends to have the same beahaviour of stack. It is
            //used if the same thread does multiple add and remove. in that case it is more efficient.
            CBag bag = new CBag();
            bag.Push("Simpsons");
            bag.Push("FamilyGuy");
            bag.Push("StarWars");


            result = bag.TryPeek(out shirt);
            if (result)
                Console.WriteLine($"The item peeked is {shirt}");
            else
                Console.WriteLine($"Error peeking. Pervert?");

            result = bag.TryPop(out shirt);

            if (result)
                Console.WriteLine($"The item poped is {shirt}");
            else
                Console.WriteLine($"Error peeking. Pervert?");

            result = bag.TryPeek(out shirt);
            if (result)
                Console.WriteLine($"The item at the Top of the stack (after Pop) is {shirt}");
            else
                Console.WriteLine($"Error peeking. Pervert?");
        }

    }
}
