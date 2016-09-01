namespace NetCore.MediatorPattern
{
    public class Board : IPart
    {

        private readonly Mediator _mediator;
        public Board()
        {
            _mediator = Mediator.GetInstance();
        }
        private decimal _price;
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
