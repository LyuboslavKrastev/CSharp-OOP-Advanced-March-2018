namespace BashSoft.Contracts.RepositoryContracts
{
    public interface IOrderedTaker
    {
        void OrderAndTake(string courseName, string comparison, int? studentsCount = null);
    }
}
