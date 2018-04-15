using System.Collections.Generic;

namespace BashSoft.Contracts.RepositoryContracts
{
    public interface IRequester
    {
        void GetStudentScoresFromCourse(string courseName, string studentName);

        void GetAllStudentsFromCourse(string courseName);

        ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> cmp);

        ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> cmp);
    }
}
