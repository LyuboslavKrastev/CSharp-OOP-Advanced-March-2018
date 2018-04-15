using System.Collections.Generic;

namespace BashSoft.Contracts.RepositoryContracts
{
    public interface IDataFilter
    {
        void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilter, int studentsToTake);
    }
}
