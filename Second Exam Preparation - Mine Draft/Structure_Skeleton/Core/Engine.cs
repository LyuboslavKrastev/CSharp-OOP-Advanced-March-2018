public class Engine
{
    private ICommandInterpreter commandInterpreter;
    private IReader reader;
    private IWriter writer;

    public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
    {
        this.commandInterpreter = commandInterpreter;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        while (true)
        {
            string[] inputArgs = reader.ReadLine().Split();

            string commandName = inputArgs[0];

            string result = this.commandInterpreter.ProcessCommand(inputArgs);

            writer.WriteLine(result);

            if (inputArgs[0] == "Shutdown")
            {
                break;
            }
        }
    }
}
