namespace NetCore.PrototypePattern
{
    public class Computer: ICloneable
    {
        public int AmountOfCores { get; set; }
        public decimal CpuFrequency { get; set; }
        public int AmountOfRam { get; set; }
        public string DriveType { get; set; }
        public GraphicsCard Gpu { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    
}
