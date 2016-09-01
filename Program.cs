using System;
using NetCore.PrototypePattern;


namespace NetCore
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
          
            PrototypePattern();

            Console.ReadLine();
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


    }
}
