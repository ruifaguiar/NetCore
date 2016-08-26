namespace StrategyPattern
{
    public class HighDiscountStrategy : IDiscountStrategy
    {
        int IDiscountStrategy.GetFinalBill(int billAmount)
        {
            return (int)(billAmount-billAmount*0.5);
        }
    }
}