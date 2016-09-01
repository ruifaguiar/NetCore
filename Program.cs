using System;

using NetCore.MediatorPatternDelegate;


namespace NetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {

            MediatorPatternDelegate();

            Console.ReadLine();
        }

        private static void MediatorPatternDelegate()
        {
            Job gardner = new Job
            {
                Title = "Gardner",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(1)
            };
            Employee john = new Employee { Name = "Peter" };
            john.Subscribe();
            Employee sara = new Employee { Name = "Raquel" };
            sara.Subscribe();
            gardner.Title = "Mr. Gardner";

        }



    }
}
