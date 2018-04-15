using BashSoft.Contracts;
using BashSoft.Contracts.RepositoryContracts;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft
{
    public class StartUp
    {
        public static void Main()
        {
            IContentComparer tester = new Tester();
            IDirectoryManager ioManager = new IOManager();
            IDatabase repo = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());

            IInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            IReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();         

        }
    }
}
