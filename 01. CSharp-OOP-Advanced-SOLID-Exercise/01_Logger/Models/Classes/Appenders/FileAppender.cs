using _Logger.Models.Classes.Loggers;
using _Logger.Models.Interfaces;

namespace _Logger.Models.Classes.Appenders
{
    public class FileAppender : IAppender
    {
        private int appendedMessages;

        public FileAppender(ILayout layout)
        {
            this.Layout = layout;
            this.File = new LogFile();
            this.appendedMessages = 0;
        }

        public ILayout Layout { get; }

        public LogFile File { get; set; }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string dateTime, string reportLevel, string message)
        {
            var formattedMessage = this.Layout.FormatMessage(dateTime, reportLevel, message);
            this.File.Write(formattedMessage);
            this.appendedMessages++;
        }

        public override string ToString()
        {
            var result = $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString()}, " +
                $"Messages appended: {this.appendedMessages}, File size: {this.File.Size}";
            return result;
        }
    }
}