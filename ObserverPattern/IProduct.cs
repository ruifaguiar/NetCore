namespace ObserverPattern
{
    public interface IProduct
    {
        //subject
        string Name{get;}
        decimal Price{get;}
        void Notify(decimal price);
         void AddFollower(ICustomer costumer);
         void RemoveFollower(ICustomer costumer);
    }
}