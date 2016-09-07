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

namespace NetCore
{
    public class Program
    {
        public delegate int AddFunction(int val1, int val2);

        public delegate void PriceUpdateHandler(Board product);
        public static void Main(string[] args)
        {
            ProxyExample();
            FactoryExample();
            SingletonExample();
            SingletonThreadSafeExample();
            DelegateExample();
            DelegateCallbackExample();
            StrategyPattern(DayOfWeek.Monday);
            StrategyPattern(DayOfWeek.Sunday);
            StrategyPattern(DayOfWeek.Thursday);
            ObserverPattern();
            PrototypePattern();
            MediatorPatternExample();
            MediatorPatternDelegate();
            InterfaceExtensions();
            EnumerableExtensionExample();
            BuilderPatternExample();
            DisposablePatternExample();

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

    }
}
