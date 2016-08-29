using System;
using DelegateExample;
using FactoryPattern;
using NetCore.PrototypePattern;
using ObserverPattern;
using ProxyPattern;
using SingletonPattern;
using StrategyPattern;
using static System.Console;
namespace ConsoleApplication
{
    public class Program
    {
        public delegate int AddFunction(int val1, int val2);
        public static void Main(string[] args)
        {
            ProxyExample();
            FactoryExample();
            SingletonExample();
            DelegateExample();
            DelegateCallbackExample();
            StrategyPattern(DayOfWeek.Monday);
            StrategyPattern(DayOfWeek.Sunday);
            StrategyPattern(DayOfWeek.Thursday);
            ObserverPattern();
            PrototypePattern();
        }
        private static void ProxyExample()
        {
            IReader reader = new FileReader();
            WriteLine(reader.Read());
            reader.Dispose();
        }

        private static void FactoryExample()
        {
            IAnimalFactory factory = AnimalFactory.CreateFactory();
            IAnimal carnivore = factory.CreateAnimal(AnimalType.Carnivore);
            IAnimal herbivore = factory.CreateAnimal(AnimalType.Herbivore);

            WriteLine("I am a {0}, i sleep for {1} hours and like to eat {2}", carnivore.GetType().Name, carnivore.Sleep(), carnivore.Eat());
            WriteLine("I am a {0}, i sleep for {1} hours and like to eat {2}", herbivore.GetType().Name, herbivore.Sleep(), herbivore.Eat());
        }

        private static void SingletonExample()
        {
            Highlander john = Highlander.GetInstance();
            Highlander rick = Highlander.GetInstance();

            var johnHash = john.GetHashCode();
            var rickHash = rick.GetHashCode();
            WriteLine(johnHash + " is equal to " + rickHash);
            WriteLine(john.Fight("John Snow"));
        }
        private static void DelegateExample()
        {
            Calculator calc = new Calculator();

            AddFunction func = new AddFunction(calc.Add);
            WriteLine(func.Invoke(1, 2));
        }
        private static void DelegateCallbackExample()
        {
            LongRunning longr = new LongRunning();
            longr.LongRunningMethod(DelegateCallbackPrint);
        }

        private static void DelegateCallbackPrint(int i)
        {
            WriteLine(i);
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

            WriteLine($"The Customer {mall.CustomerName} is bought {mall.BillAmount}€ and got a discount of {100 - discount * 100}%");
        }

        private static void ObserverPattern()
        {
            var component = new Cpu(150);
            var ramProduct = new Ram(75);
            ICustomer cust1 = new Customer();
            ICustomer cust2 = new Customer();
            component.AddFollower(cust1);
            ramProduct.AddFollower(cust2);

            component.Price=100;
            ramProduct.Price=25;

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

            var computer2 = (Computer) computer.Clone();
            WriteLine($"Are both computer the same reference? {ReferenceEquals(computer, computer2)}");
            
            WriteLine($"Computer 1 has {computer.AmountOfCores} cores and computer 2 has {computer2.AmountOfCores}");
            WriteLine($"Computer 1 has {computer.AmountOfRam} GB of Ram and computer 2 has {computer2.AmountOfRam}");
            WriteLine($"Computer 1 cores have {computer.CpuFrequency}  and computer 2 have {computer2.CpuFrequency}");
            WriteLine($"Computer 1 drive is {computer.DriveType} and computer 2 has {computer2.DriveType}");
            WriteLine($"Are both drives(string) pointing to the same reference? { ReferenceEquals(computer.DriveType,computer2.DriveType)}");
            WriteLine($"Are both Gpu's(Class) pointing to the same reference? { ReferenceEquals(computer.Gpu, computer2.Gpu)}");
        }
    }
}
