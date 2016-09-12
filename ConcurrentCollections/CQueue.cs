using System.Collections.Concurrent;

namespace NetCore.ConcurrentCollections
{
    public class CQueue
    {
        ConcurrentQueue<string> _queue = new ConcurrentQueue<string>();

        public void Enqueue(string shirt)
        {
            _queue.Enqueue(shirt);
        }

        public bool TryDequeue(out string shirt)
        {
            return _queue.TryDequeue(out shirt);
        }

        public bool TryPeek(out string shirt)
        {
            return _queue.TryPeek(out shirt);
        }
    }
}
