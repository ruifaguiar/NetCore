namespace StrategyPattern
{
    public interface IDiscountStrategy
    {
        int GetFinalBill(int billAmount);
    }
}