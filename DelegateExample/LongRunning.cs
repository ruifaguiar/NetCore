using System.Threading.Tasks;

namespace NetCore.DelegateExample
{
    public class LongRunning
    {
        public delegate void Callback(string i);

        public void LongRunningMethod(Callback cal)
        {

            Task.Run(async () =>
            {
                await Task.Delay(5000);

                cal("After 5000ms we get the callback");
            });


        }

    }
}