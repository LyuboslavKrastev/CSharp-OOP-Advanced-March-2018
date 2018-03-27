using _Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _Logger.Core
{
    public class Engine
    {
        private ILogger logger;

        public Engine(ILogger logger)
        {
            this.logger = logger;
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var args = input.Split('|');

                var reportLevel = args[0];
                var dateTime = args[1];
                var message = args[2];

                switch (reportLevel)
                {
                    case "INFO":
                        logger.Info(dateTime, message);
                        break;
                    case "WARNING":
                        logger.Warn(dateTime, message);
                        break;
                    case "ERROR":
                        logger.Error(dateTime, message);
                        break;
                    case "CRITICAL":
                        logger.Critical(dateTime, message);
                        break;
                    case "FATAL":
                        logger.Fatal(dateTime, message);
                        break;
                }
            }

            Console.WriteLine("Logger info");

            foreach (IAppender appender in this.logger.appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
