using System.Collections.Concurrent;

namespace NetCore.ConcurrentCollections
{
    public class CStack
    {
        ConcurrentStack<string> _stack = new ConcurrentStack<string>();

        public void Push(string shirt)
        {
            _stack.Push(shirt);
        }

        public bool TryPop(out string shirt)
        {
            return _stack.TryPop(out shirt);
        }

        public bool TryPeek(out string shirt)
        {
            return _stack.TryPeek(out shirt);
        }
    }
}
