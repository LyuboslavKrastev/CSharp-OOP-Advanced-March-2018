using System;

namespace BashSoft.Exceptions
{
    public class InvalidNumberOfScoresException : Exception
    {
        public const string InvalidNumberOfScores = "The number of scores for the given course is greater than the possible.";

        public override string Message => InvalidNumberOfScores;
    }
}
