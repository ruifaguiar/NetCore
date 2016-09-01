using System;

namespace NetCore.MediatorPattern
{
    public class Client
    {
        private static Mediator _mediator;
        public Client()
        {
            _mediator = Mediator.GetInstance();
        }
        public string NameOfClient { get; set; }

        public void SubscribePart(IPart part)
        {
            _mediator.AddSubscriber(this, part);
        }

        public void HandlePartUpdate(ProductChangeEventArgs e)
        {
            Console.WriteLine($"I {NameOfClient} recieved an update for Part {e.Part.Name} for the price of {e.Part.Price}");
        }
    }
}
