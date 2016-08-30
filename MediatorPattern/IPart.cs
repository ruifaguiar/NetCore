namespace NetCore.MediatorPattern
{
    public interface IPart
    {
        string Name { get; }
        decimal Price { get; set; }

        void Notify();
    }
}
