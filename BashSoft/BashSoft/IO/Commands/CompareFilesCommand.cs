using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.Attributes;

namespace BashSoft.IO.Commands
{
    [Alias("cmp")]
    public class CompareFilesCommand : Command
    {
        [Inject]
        private IContentComparer judge;
  
        public CompareFilesCommand(string input, string[] data)
            : base(input, data) { }

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            string userOutputPath = this.Data[1];
            string expectedOutputPath = this.Data[2];
            this.judge.CompareContent(userOutputPath, expectedOutputPath);
        }
    }
}
