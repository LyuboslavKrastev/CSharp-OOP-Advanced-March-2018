namespace _Logger.Models.Interfaces
{
    public interface ILayout
    {
        string FormatMessage(string timeStamp, string reportLevel, string message);
    }
}
