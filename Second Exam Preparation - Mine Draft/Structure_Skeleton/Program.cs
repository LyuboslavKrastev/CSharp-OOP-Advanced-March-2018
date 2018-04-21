public class Program
{
    public static void Main(string[] args)
    {
       
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        IHarvesterFactory harvesterFactory = new HarvesterFactory();
        IEnergyRepository energyRepository = new EnergyRepository();

        IHarvesterController harvesterController = new HarvesterController(energyRepository, harvesterFactory);
        IProviderController providerController = new ProviderController(energyRepository);

        ICommandInterpreter commandInterpreter = new CommandInterpreter(harvesterController, providerController);

        Engine engine = new Engine(commandInterpreter, reader, writer);
        engine.Run();
    }
}