using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace RepositoryPattern.ImplXml
{
    public class StudentRepository : BaseRepository<Student, int>, IStudentRepository
    {

        public StudentRepository(IOptionsSnapshot<RepositortOptions> options) : base(options)
        { }

        public IEnumerable<Student> GetStudentsByGender(string gender)
        {
            throw new System.NotImplementedException();
        }
    }
}
