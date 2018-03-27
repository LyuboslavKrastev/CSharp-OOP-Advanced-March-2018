using _Logger.Models.Interfaces;
using System.Text;

namespace _Logger.Models.Classes.Layouts
{
    public class XmlLayout : ILayout
    {
        public string FormatMessage(string dateTime, string reportLevel, string message)
        {
            var sb = new StringBuilder();

            sb.AppendLine("<log>")
                .AppendLine($"  <date>{dateTime}</date>")
                .AppendLine($"  <level>{reportLevel}</level>")
                .AppendLine($"  <message>{message}</message>")
                .Append("</log>");

            return sb.ToString().TrimEnd();
        }
    }
}

