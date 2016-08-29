namespace NetCore.StrategyPattern
{
    public class ShoppingMall
    {
        public string CustomerName{get;set;}
        public int BillAmount{get;set;}
        public IDiscountStrategy CurrentStrategy;
        public ShoppingMall(IDiscountStrategy discountStrategy)
        {
            CurrentStrategy=discountStrategy;
        }

        public int GetFinalBill()
        {
            return CurrentStrategy.GetFinalBill(BillAmount);
        }
    }
}