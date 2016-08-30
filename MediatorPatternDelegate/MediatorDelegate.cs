using System;

namespace NetCore.MediatorPatternDelegate
{
    public sealed class MediatorDelegate
    {
        private static readonly MediatorDelegate Instance = new MediatorDelegate();

        private MediatorDelegate()
        {

        }

        public static MediatorDelegate GetInstance()
        {
            return Instance;
        }

        public event EventHandler<JobChangedEventArgs> JobChanged;

        public void OnJobChanged(object sender, Job job)
        {
            var jobDelegate = JobChanged;
            jobDelegate?.Invoke(sender, new JobChangedEventArgs { Job = job });
        }
    }
}
