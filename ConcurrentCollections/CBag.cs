using System.Collections.Concurrent;

namespace NetCore.ConcurrentCollections
{
    public class CBag
    {
        ConcurrentBag<string> _bag = new ConcurrentBag<string>();

        public void Push(string shirt)
        {
            _bag.Add(shirt);
        }

        public bool TryPop(out string shirt)
        {
            return _bag.TryTake(out shirt);
        }

        public bool TryPeek(out string shirt)
        {
            return _bag.TryPeek(out shirt);
        }
    }
}
