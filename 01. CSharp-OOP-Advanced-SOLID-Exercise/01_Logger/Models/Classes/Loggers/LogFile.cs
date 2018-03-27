using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _Logger.Models.Classes.Loggers
{
    public class LogFile
    {
        private const string DefaultFileName = "log.txt";

        private StringBuilder sb;

        public LogFile()
        {
            this.sb = new StringBuilder();
        }

        public int Size { get; private set; }

        private int GetLettersSum(string message)
        {
            return message.Where(c => char.IsLetter(c)).Sum(c => c);
        }

        public void Write(string formattedMessage)
        {
            this.sb.AppendLine(formattedMessage);
            File.AppendAllText(DefaultFileName, formattedMessage + Environment.NewLine);
            this.Size += this.GetLettersSum(formattedMessage);
        }
    }
}

