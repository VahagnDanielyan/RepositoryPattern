using RepositoryPattern;

internal class StudentCreator
{
    public static IEnumerable<Student> CreateStudents(int count)
    {
        var genders = new List<string>() { "Male", "Female"};
        Random r = new();

        for (int i = 1; i <= count; i++)
        {
            yield return new Student
            {
                Id = i,
                Gender = genders[r.Next(genders.Count)],
                Name = $"A{i}",
                Surname = $"A{i}yan",
                Email = $"a{i}@gmail.com"
            };
        }
    }

    public static IEnumerable<Teacher> CreateTeachers(int count)
    {
        var genders = new List<string>() { "Male", "Female" };
        Random r = new();

        for (int i = 1; i <= count; i++)
        {
            yield return new Teacher
            {
                Id = i,
                Gender = genders[r.Next(genders.Count)],
                Name = $"A{i}",
                Surname = $"A{i}yan",
                Email = $"a{i}@gmail.com"
            };
        }
    }
}