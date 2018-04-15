using BashSoft.Exceptions;
using System.Diagnostics;
using System.IO;
using BashSoft.Attributes;

namespace BashSoft.IO.Commands
{
    [Alias("open")]
    public class OpenFileCommand : Command
    {
        public OpenFileCommand(string input, string[] data)
            : base(input, data) { }

        public override void Execute()
        {

            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            var fileName = this.Data[1];
            var filePath = SessionData.currentPath + "\\" + fileName;

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            Process.Start(filePath);
        }
    }
}
