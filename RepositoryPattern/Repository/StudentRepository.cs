using System.Collections.Generic;

namespace RepositoryPattern
{
    public class StudentRepository : BaseRepository<Student, int>, IStudentRepository
    {

        public StudentRepository() : base($"{nameof(Student)}.xml")
        {

        }

        public IEnumerable<Student> GetStudentsByGender(string gender)
        {
            throw new System.NotImplementedException();
        }
    }
}
