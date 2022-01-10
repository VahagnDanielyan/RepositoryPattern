using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern;

namespace Client
{
    public class Program
    {
        static IServiceProvider serviceProvider;

        static void Main()
        {
            Configure();

            var teacherRepository = serviceProvider.GetRequiredService<ITeacherRepository>();
            var stRepository = serviceProvider.GetRequiredService<IStudentRepository>();

            //var stRepository = serviceProvider.GetRequiredService<IStudentRepository>();
            //foreach (var st in StudentCreator.CreateStudents(10))
            //{
            //    stRepository.Insert(st);
            //}

            //stRepository.Save();
        }

        static void Configure()
        {
            var services = new ServiceCollection();
            services.AddRepositories(new()
            {
                { nameof(Student),  cfg => cfg.Filename = $"{nameof(Student)}.xml"},
                { nameof(Teacher),  cfg => cfg.Filename = $"{nameof(Teacher)}.xml"},
            });

            serviceProvider = services.BuildServiceProvider();
        }
    }
}

//IStudentRepository source = new StudentRepository($"{nameof(Student)}.xml");
//foreach (var st in StudentCreator.CreateStudents(10))
//{
//    source.Insert(st);
//}

//source.GetAll();
//var st1 = source.GetByID(3);
//st1.Name = "updatedA3";
//source.Update(st1);
//source.GetAll();
//source.Delete(4);
//source.GetAll();

//Console.ReadLine();
