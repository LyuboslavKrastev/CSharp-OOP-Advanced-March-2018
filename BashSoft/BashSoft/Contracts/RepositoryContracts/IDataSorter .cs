using System.Collections.Generic;


namespace BashSoft.Contracts.RepositoryContracts
{
    public interface IDataSorter
    {
        void OrderAndTake(Dictionary<string, double> studentsMarks, string comparison, int studentsToTake);
    }
}
