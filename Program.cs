using NetCore.DelegateExample;
using static System.Console;


namespace NetCore
{
    /// <summary>
    /// Uses a delegate to perform 
    /// </summary>
    public class Program
    {
        public delegate int MathFunction(int val1, int val2);

        public static void Main(string[] args)
        {
            WriteLine(DelegateExample('+', 1, 2));
            WriteLine(DelegateExample('*', 3, 2));

            WriteLine("Press any key");
            ReadLine();

        }

        private static int DelegateExample(char x, int val1, int val2)
        {
            var calc = new Calculator();
            MathFunction func;

            //Place some logic here. The main objective is that the delegate can be specified at runtime
            switch (x)
            {
                case '+':
                    {
                        func = calc.Add;
                        break;
                    }
                case '*':
                    {
                        func = calc.Multiply;
                        break;
                    }
                default:
                    {
                        func = null;
                        break;
                    }
            }
            var result = func?.Invoke(val1, val2);
            return result ?? 0;

        }
    }
}
