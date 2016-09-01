namespace NetCore.PrototypePattern
{
    public class GraphicsCard: ICloneable
    {
        public decimal GpuFrequency { get; set; }
        public int AmountOfRam { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
