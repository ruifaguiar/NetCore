using System.Collections.Generic;
using System.Linq;
using NetCore.MediatorPattern;

namespace NetCore.MediatorPattern
{
    public sealed class Mediator
    {
        private readonly Dictionary<IPart, IList<Client>> _subscriptionList;
        private static Mediator _instance;

        private Mediator()
        {
            _subscriptionList = new Dictionary<IPart, IList<Client>>();
        }

        public static Mediator GetInstance()
        {
            return _instance ?? (_instance = new Mediator());
        }

    

        public void OnProductChanged(object sender, ProductChangeEventArgs product)
        {
            IEnumerable<IList<Client>> channels = _subscriptionList.Where(a => a.Key.GetType() == product.Part.GetType()).Select(a=>a.Value);
            foreach (IList<Client> channel in channels)
            {
                foreach (Client client in channel)
                {
                    client.HandlePartUpdate(product);
                }
            }
        }

        public void AddSubscriber(Client subscriber, IPart part)
        {
            if (!_subscriptionList.ContainsKey(part))
                _subscriptionList.Add(part, new List<Client> { subscriber });
            if (!_subscriptionList[part].Contains(subscriber))
                _subscriptionList[part].Add(subscriber);
        }

    }
}
