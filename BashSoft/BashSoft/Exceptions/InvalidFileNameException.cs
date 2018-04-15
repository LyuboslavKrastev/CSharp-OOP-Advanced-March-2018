﻿using System;

namespace BashSoft.Exceptions
{
    public class InvalidFileNameException : Exception
    {
        public const string ForbiddenSymbolsContainedInName = 
            "The given name contains symbols that are not allowed to be used in names of files and folders.";

        public override string Message => ForbiddenSymbolsContainedInName;

    }
}