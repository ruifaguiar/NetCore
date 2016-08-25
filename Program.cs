using DelegateExample;
using FactoryPattern;
using ProxyPattern;
using SingletonPattern;
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
    }
}
