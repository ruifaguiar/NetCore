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
            if (_highlander == null)
            {
                _highlander = new Highlander();
            }
            return _highlander;
        }

       
    }
}
