using System;

namespace NetCore.MediatorPatternDelegate
{
    public class Employee
    {
        public string Name { get; set; }

        private void JobChangeEventHandler(JobChangedEventArgs e)
        {
            Console.WriteLine($"I {Name} received an update for the Job {e.Job.Title}");
        }

        public void Subscribe()
        {
            MediatorDelegate.GetInstance().JobChanged += (s, e) =>
            {
                JobChangeEventHandler(e);
            };
        }
    }
}
