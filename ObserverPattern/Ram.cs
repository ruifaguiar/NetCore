using System.Collections.Generic;

namespace ObserverPattern
{

    public class Ram : IProduct
    {
        private delegate void PriceUpdate(IProduct product);
        private event PriceUpdate OnPriceUpdate;
        private decimal _price;

        public Ram(decimal price)
        {
            _price = price;
        }
        public string Name => "Ram";

        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                Notify(value);
            }
        }

        public void Notify(decimal price)
        {
           _price=price;
            OnPriceUpdate?.Invoke(this);
        }

        public void AddFollower(ICustomer costumer)
        {
           OnPriceUpdate+=costumer.Update;
        }
        public void RemoveFollower(ICustomer costumer)
        {
            OnPriceUpdate -=costumer.Update;
        }
    }
}