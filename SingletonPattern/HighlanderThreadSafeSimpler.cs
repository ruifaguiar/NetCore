namespace NetCore.SingletonPattern
{
    public sealed class HighlanderThreadSafeSimpler
    {
        private static readonly HighlanderThreadSafeSimpler _instance=new HighlanderThreadSafeSimpler();
        //with static initializers you cannot have more than one thread initializing it.The CLR manages it.

        public static HighlanderThreadSafeSimpler Instance => _instance;

        public void DoStuff()
        {
            
        }
    }
}
