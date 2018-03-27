using _Logger.Models.Interfaces;
using System;

namespace _Logger.Models.Classes.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private int appendedMessages;

        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
            this.appendedMessages = 0;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }


        public void Append(string dateTime, string reportLevel, string message)
        {
            var formattedMessage = this.Layout.FormatMessage(dateTime, reportLevel, message);
            Console.WriteLine(formattedMessage);

            appendedMessages++;
        }

        public override string ToString()
        {
            var result = $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString()}, " +
                $"Messages appended: {this.appendedMessages}";
            return result;
        }
    }
}

