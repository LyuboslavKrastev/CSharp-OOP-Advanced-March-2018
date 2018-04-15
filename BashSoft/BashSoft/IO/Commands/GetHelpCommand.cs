using System.Text;
using BashSoft.Exceptions;
using BashSoft.Attributes;

namespace BashSoft.IO.Commands
{
    [Alias("help")]
    public class GetHelpCommand : Command
    {
        public GetHelpCommand(string input, string[] data)
            : base(input, data) { }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.DisplayHelp();
        }

       private void DisplayHelp()
        {
            var helpBuilder = new StringBuilder();

            helpBuilder.AppendLine($"{new string('_', 99)}")
            .AppendLine(string.Format("|{0, -98}|", " make directory - mkdir: path (For example: mkdir NewDirectory)"))
            .AppendLine(string.Format("|{0, -98}|", " traverse directory - ls: depth (For example: ls 2)"))
            .AppendLine(string.Format("|{0, -98}|", @" comparing files - cmp: path1 path2 (For example: cmp Files\test2.txt Files\test3.txt)"))
            .AppendLine(string.Format("|{0, -98}|", " change directory - cdrel: relative path (For example: cdrel ..)"))
            .AppendLine(string.Format("|{0, -98}|", " change directory - cdabs: absolute path (For example: cdabs C:\\"))
            .AppendLine(string.Format("|{0, -98}|", @" read students data base - readdb: path (For example: readdb Files\data.txt)"))
            .AppendLine(string.Format("|{0, -98}|", " drop data base - dropdb"))
            .AppendLine(string.Format("|{0, -98}|", " show {courseName} - show: {courseName} (For example: show C#_Feb_2015)"))
            .AppendLine(string.Format("|{0, -98}|", " show {courseName} and {student} - show: course student"))
            .AppendLine(string.Format("|{0, -98}|", "   (For example: show C#_Feb_2015 JeanWalker83_2820)"))
            .AppendLine(string.Format("|{0, -98}|", " filter {courseName} excelent/average/poor take 2/5/all students"))
            .AppendLine(string.Format("|{0, -98}|", "   (For example: filter C#_Feb_2015 excelent take all)"))
            .AppendLine(string.Format("|{0, -98}|", " order {students} - order {courseName} ascending/descending take 20/10/all"))
            .AppendLine(string.Format("|{0, -98}|", "   (For example: order C#_Feb_2015 descending take 1)"))
            .AppendLine(string.Format("|{0, -98}|", " display data entities - display students/courses ascending/descending"))
            .AppendLine(string.Format("|{0, -98}|", "   (For example: display courses descending)"))
            .AppendLine(string.Format("|{0, -98}|", " get help – help"))    
            .AppendLine($"|{new string('_', 98)}|");

            OutputWriter.WriteMessageOnNewLine(helpBuilder.ToString());
            OutputWriter.WriteEmptyLine();
}
    }
}
