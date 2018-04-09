using System;

namespace P09_DateTimeMocking
{
    public interface ITimeProvider
    {
        DateTime Now { get; }
    }
}

