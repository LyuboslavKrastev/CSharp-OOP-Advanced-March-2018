using System;
using P06_Twitter.Contracts;

namespace P06_Twitter.IO.Writers
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
