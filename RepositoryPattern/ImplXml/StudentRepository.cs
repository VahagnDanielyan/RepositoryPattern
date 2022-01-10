using System.Collections.Generic;

namespace RepositoryPattern.ImplXml
{
    public class StudentRepository : BaseRepository<Student, int>, IStudentRepository
    {

        public StudentRepository(string fileName) : base(fileName)
        {

        }

        public IEnumerable<Student> GetStudentsByGender(string gender)
        {
            throw new System.NotImplementedException();
        }
    }
}
