using System.Collections.Generic;

namespace NetCore.ObserverPattern
{
    public class Cpu : IProduct
    {
        //Concrete Subject
       public Cpu(decimal price)
       {
           _customers = new List<ICustomer>();
           _price=price;
       }
        private decimal _price;
        private readonly IList<ICustomer> _customers;
        public string Name
        {
            get
            {
                return "CPU";
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
            foreach(var c in _customers)
            {
                c.Update(this);
            }
        }

        public void AddFollower(ICustomer costumer)
        {
            _customers.Add(costumer);
        }
        public void RemoveFollower(ICustomer costumer)
        {
            _customers.Remove(costumer);
        }
    }
}