namespace NetCore.SingletonPattern
{
    public sealed class HighlanderThreadSafe
    {
        private HighlanderThreadSafe()
        {

        }

        private static HighlanderThreadSafe _instance;
        private static readonly object Mutex = new object(); //this object has only 2 states -> lock or unlocked

        public static HighlanderThreadSafe GetInstance()
        {
            lock (Mutex) // this way only 1 thread can create a new instance of 
            {
                if (_instance == null)
                {
                    _instance = new HighlanderThreadSafe();
                }
                return _instance;
            }
        }
    }
}
