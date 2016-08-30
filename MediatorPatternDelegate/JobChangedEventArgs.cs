using System;

namespace NetCore.MediatorPatternDelegate
{
    public class JobChangedEventArgs:EventArgs
    {
        public Job Job { get; set; }
    }
}
