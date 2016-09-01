using System;

namespace NetCore.MediatorPatternDelegate
{
    public class Job
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyChange();
            }
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private void NotifyChange()
        {
            MediatorDelegate.GetInstance().OnJobChanged(null, this);
        }
    }
}
