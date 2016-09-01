namespace NetCore.StrategyPattern
{
    public class NoDiscountStrategy : IDiscountStrategy
    {
        int IDiscountStrategy.GetFinalBill(int billAmount)
        {
            return billAmount;
        }
    }
}