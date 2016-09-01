namespace NetCore.SingletonPattern
{
    public sealed class Highlander
    {
        private Highlander()
        {

        }
        private static Highlander _highlander;

        public static Highlander GetInstance()
        {
            return _highlander ?? (_highlander = new Highlander());
        }
    }
}
