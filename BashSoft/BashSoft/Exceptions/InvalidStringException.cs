using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Exceptions
{
    public class InvalidStringException : Exception
    {
        public const string NullOrEmptyValue = "The value of the variable CANNOT be null or empty!";

        public override string Message => NullOrEmptyValue;
    }
}
