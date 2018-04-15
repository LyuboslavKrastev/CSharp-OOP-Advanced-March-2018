namespace BashSoft.Contracts.RepositoryContracts
{
    public interface IDatabase : IRequester, IFilteredTaker, IOrderedTaker
    {
        void LoadData(string fileName);
        void UnloadData();
    }
}
