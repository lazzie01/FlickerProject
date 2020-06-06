using System;

namespace API.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
    }

    public static class Calculate
    {
        public static int  DateDifferenceInYrs(DateTime a, DateTime b)
        {
          
            if (a.Year != b.Year)
            {
                DateTime zeroTime = new DateTime(1, 1, 1);
                TimeSpan span = a - b;
                // Because we start at year 1 for the Gregorian
                // calendar, we must subtract a year here.
                int years = Math.Abs((zeroTime + span).Year - 1);
                return years;
            }
            return 0;
            
        }
    }
}
