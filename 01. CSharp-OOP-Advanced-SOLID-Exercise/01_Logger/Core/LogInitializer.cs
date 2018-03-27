using _Logger.Core.Factories;
using _Logger.Models;
using _Logger.Models.Classes.Loggers;
using _Logger.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace _Logger.Core
{
    public class LogInitializer
    {
        public  ILogger InitializeLogger()
        {
            var appenders = new List<IAppender>();

            var layoutFactory = new LayoutFactory();
            var appenderFactory = new AppenderFactory(layoutFactory);

            int appenderCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appenderCount; i++)
            {
                var input = Console.ReadLine().Split();

                var appenderType = input[0];
                var layoutType = input[1];
                var reportLevel = "INFO";

                if (input.Length == 3)
                {
                    reportLevel = input[2];
                }

                var appender = appenderFactory.CreateAppender(appenderType, layoutType);
                bool isValidReportLevel = Enum.TryParse(typeof(ReportLevel), reportLevel, out object repLevel);

                if (isValidReportLevel)
                {
                    appender.ReportLevel = (ReportLevel)repLevel;
                }
                appenders.Add(appender);
            }
            var logger = new Logger(appenders);

            return logger;
        }
    }
}
