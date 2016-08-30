namespace NetCore.DelegatePublishSubscribe
{
    public class Product
    {
        private int _price;
        public string ProductName { get; set; }

        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                Notify();
            }
        }

        private delegate void PriceUpdate(Product product);

        private event PriceUpdate OnPriceUpdate;

        public void AddToList(Client client)
        {
            OnPriceUpdate += client.PriceNotificationHandler;
        }

        public void Notify()
        {
           OnPriceUpdate?.Invoke(this);
        }
    }
}
