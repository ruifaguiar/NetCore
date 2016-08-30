using NetCore.MediatorPattern;

namespace NetCore.MediatorPattern
{
    public class Transistor : IPart
    {
        private decimal _price;
        private readonly Mediator _mediator;

        public Transistor()
        {
            _mediator = Mediator.GetInstance();
        }
        public string Name { get; set; }

        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                Notify();
            }
        }

        public void Notify()
        {
            _mediator.OnProductChanged(this, new ProductChangeEventArgs(this));
        }
    }
}
