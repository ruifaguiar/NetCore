using System;

namespace NetCore.ProxyPattern

{
     public interface IReader : IDisposable
    {
        string Read();
    }
}