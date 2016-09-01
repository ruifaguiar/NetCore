namespace NetCore.StrategyPattern
{
    public class LowDiscountStrategy : IDiscountStrategy
    {
        int IDiscountStrategy.GetFinalBill(int billAmount)
        {
            return (int) (billAmount-billAmount*0.1);
        }
    }
}