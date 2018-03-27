using _Logger.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace _Logger.Models.Classes.Loggers
{
    public class Logger : ILogger
    {
        public ICollection<IAppender> appenders { get; }


        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        private void Log(string dateTime, string reportLevel, string message)
        {
            foreach (IAppender appender in this.appenders)
            {
                bool isValidReportLevel = Enum.TryParse(typeof(ReportLevel), reportLevel, out object repLevel);

                if (isValidReportLevel)
                {
                    var currentReportLevel = (ReportLevel)repLevel;

                    bool isBelowTreshold = appender.ReportLevel > currentReportLevel;

                    if (!isBelowTreshold)
                    {
                        appender.Append(dateTime, reportLevel, message);
                    }
                }
            }
        }

        public void Error(string dateTime, string message)
        {
            this.Log(dateTime, ReportLevel.ERROR.ToString(), message);
        }

        public void Info(string dateTime, string message)
        {
            this.Log(dateTime, ReportLevel.INFO.ToString(), message);
        }

        public void Fatal(string dateTime, string message)
        {
            this.Log(dateTime, ReportLevel.FATAL.ToString(), message);
        }

        public void Critical(string dateTime, string message)
        {
            this.Log(dateTime, ReportLevel.CRITICAL.ToString(), message);
        }

        public void Warn(string dateTime, string message)
        {
            this.Log(dateTime, ReportLevel.WARNING.ToString(), message);
        }
    }
}