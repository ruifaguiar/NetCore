namespace NetCore.ExtensionsExample
{
    public class RomMemoryCollection : MemoryCollection
    {
        public RomMemoryCollection(string romType)
        {
            RomType = romType;
        }
        public string RomType { get; }
    }
}
