using System;
using NetCore.StrategyPattern;

namespace NetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StrategyPattern(DayOfWeek.Monday);
            StrategyPattern(DayOfWeek.Sunday);
            StrategyPattern(DayOfWeek.Thursday);


            Console.ReadLine();
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

            Console.WriteLine($"The Customer {mall.CustomerName} has bought {mall.BillAmount} and got a discount of {100 - discount * 100}%");
        }

       

    }
}
