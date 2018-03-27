namespace _Logger.Models.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        void Append(string dateTime, string reportLevel, string message);

    }
}
