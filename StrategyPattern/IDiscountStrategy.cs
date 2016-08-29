namespace NetCore.StrategyPattern
{
    public interface IDiscountStrategy
    {
        int GetFinalBill(int billAmount);
    }
}