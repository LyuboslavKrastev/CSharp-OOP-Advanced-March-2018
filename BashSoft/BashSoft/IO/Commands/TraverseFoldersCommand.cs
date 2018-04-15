using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.Attributes;

namespace BashSoft.IO.Commands
{
    [Alias("ls")]
    public class TraverseFoldersCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public TraverseFoldersCommand(string input, string[] data)
            : base(input, data) { }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            int depth = int.Parse(this.Data[1]);
            this.inputOutputManager.TraverseDirectory(depth);
        }
    }
}
