namespace BashSoft.Contracts.RepositoryContracts
{
    public interface IFilteredTaker
    {
        void FilterAndTake(string courseName, string givenFilter, int? studentsCount = null);
    }
}
