using System.Threading.Tasks;

namespace NetCore.DelegateExample
{
    public class LongRunning
    {
        public delegate void Callback(int i);

        public void LongRunningMethod(Callback cal)
        {
            for (int i = 0; i < 5; i++)
            {
                Task.Delay(i * 1000);
                cal(i);
            }
        }

    }
}