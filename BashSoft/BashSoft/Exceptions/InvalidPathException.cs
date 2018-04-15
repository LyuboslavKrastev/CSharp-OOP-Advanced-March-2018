using System;

namespace BashSoft.Exceptions
{
    public class InvalidPathException : Exception
    {
        public const string InvalidPath = "The source does not exist.";

        public override string Message => InvalidPath;
    }
}
