using System;

namespace ProxyPattern

{
     public interface IReader : IDisposable
    {
        string Read();
    }
}