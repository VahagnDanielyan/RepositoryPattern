using System.Collections.Generic;

namespace RepositoryPattern
{
    public interface IStudentRepository : IBaseRepository<Student, int>
    {
        IEnumerable<Student> GetStudentsByGender(string gender);
    }
}
