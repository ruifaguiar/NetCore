using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.ConcurrentCollections
{
    public class CDictionary
    {
        private ConcurrentDictionary<string, int> _stock;
        
        public CDictionary()
        {
            _stock = new ConcurrentDictionary<string, int>();
        }

        public int AddOrUpdate(string tshirt, int startStock)
        {
            return _stock.AddOrUpdate(tshirt, startStock, (k, v) => v + 1);
        }

        public int GetOrAdd(string tshirt, int startStock)
        {
            return _stock.GetOrAdd(tshirt, startStock);
        }

        public bool TryAdd(string tshirt, int stockChange)
        {
            return _stock.TryAdd(tshirt, stockChange);
        }

        public bool TryRemove(string tshirt, out int numberOfShirts)
        {
            return _stock.TryRemove(tshirt, out numberOfShirts);
        }

        public bool TryUpdate(string tshirt, int oldValue, int newValue)
        {
            return _stock.TryUpdate(tshirt, newValue, oldValue);
        }

        public bool TryGet(string tshirt, out int stockNumber)
        {

            return _stock.TryGetValue(tshirt, out stockNumber);
        }

    }
}
