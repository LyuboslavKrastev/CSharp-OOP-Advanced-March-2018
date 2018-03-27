using _Logger.Core;

namespace _01_Logger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var logInitializer = new LogInitializer();
            var logger = logInitializer.InitializeLogger();
            var engine = new Engine(logger);
            engine.Run();
        }      
    }
}
