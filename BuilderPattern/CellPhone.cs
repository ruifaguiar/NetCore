namespace NetCore.BuilderPattern
{
    public sealed class CellPhone
    {
        private readonly string _cpu;
        private readonly int? _memory;
        private readonly int? _memoryCapacity;
        private readonly string _screenType;
        private readonly int? _microSdSlot;

        private CellPhone(CellPhoneBuilder builder)
        {
            _cpu = builder.Cpu;
            _memory = builder.Memory;
            _memoryCapacity = builder.MemoryCapacity;
            _screenType = builder.ScreenType;
            _microSdSlot = builder.MicroSdSlot;
        }

        public override string ToString()
        {
            return
                $"This computer has an {_cpu}, {_memory} GB,{_memoryCapacity} GB of capacity, screen of {_screenType} and {_microSdSlot ?? 0 : _microSdSlot.Value}";
        }

        public sealed class CellPhoneBuilder
        {
            public string Cpu { get; set; }
            public int? Memory { get; set; }
            public int? MemoryCapacity { get; set; }
            public string ScreenType { get; set; }
            public int? MicroSdSlot { get; set; }

            public CellPhone Build()
            {
                return new CellPhone(this);
            }



        }

    }
}
