using _Logger.Models.Interfaces;

namespace _Logger.Models.Classes.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string FormatMessage(string dateTime, string reportLevel, string message)
        {
            return $"{dateTime} - {reportLevel} - {message}";
        }
    }
}

