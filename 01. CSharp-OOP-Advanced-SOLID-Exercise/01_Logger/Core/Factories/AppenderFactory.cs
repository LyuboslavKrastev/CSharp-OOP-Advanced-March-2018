using _Logger.Models.Classes.Appenders;
using _Logger.Models.Interfaces;
using System;

namespace _Logger.Core.Factories
{
    public class AppenderFactory
    {
        private LayoutFactory LayoutFactory;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.LayoutFactory = layoutFactory;
        }
        public IAppender CreateAppender(string appenderType, string layoutType)
        {
            var layout = this.LayoutFactory.CreateLayout(layoutType);

            switch (appenderType)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout);
                case "FileAppender":
                    return new FileAppender(layout);
                default:
                    throw new ArgumentException("Invalid Appender Type!");
            }

        }
    }
}
