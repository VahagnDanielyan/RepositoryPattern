using Microsoft.Extensions.Options;

namespace RepositoryPattern.ImplXml
{
    public class TeacherRepository : BaseRepository<Teacher, int>, ITeacherRepository
    {
        public TeacherRepository(IOptionsSnapshot<RepositortOptions> options) : base(options)
        { }
    }
}
