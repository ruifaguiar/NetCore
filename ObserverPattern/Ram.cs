using System.Collections.Generic;

namespace ObserverPattern
{

    public class Ram : IProduct
    {
        private delegate void PriceUpdate(IProduct product);
        private event PriceUpdate OnPriceUpdate;
        private decimal _price;
        private readonly IList<ICustomer> _customers;
        public Ram(decimal price)
        {
            _customers = new List<ICustomer>();
            _price = price;
        }
        public string Name
        {
            get
            {
                return "Ram";
            }
        }

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
           if(OnPriceUpdate!=null)
           {
               OnPriceUpdate(this);
           }
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