using System;

namespace P09_DateTimeMocking
{
    public class CustomDateTime : ITimeProvider
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}
