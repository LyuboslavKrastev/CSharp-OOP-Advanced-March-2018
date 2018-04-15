using Microsoft.Extensions.DependencyInjection;
using P07_InfernoInfinity.Core;
using P07_InfernoInfinity.Core.Factories;
using P07_InfernoInfinity.Interfaces;
using P07_InfernoInfinity.Models;

using System;

namespace P07_InfernoInfinity
{
    class StartUp
    {
        public static void Main()
        {
            IServiceProvider serviceProvider = ConfigureServices();

            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);

            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<WeaponFactory>();
            services.AddTransient<GemFactory>();
            services.AddTransient<ICommandInterpreter, CommandInterpreter>();
            services.AddSingleton<IRepository, WeaponRepository>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;

        }
    }
}
