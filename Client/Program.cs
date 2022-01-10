using RepositoryPattern;

IStudentRepository source = new StudentRepository($"{nameof(Student)}.xml");
foreach (var st in StudentCreator.CreateStudents(10))
{
    source.Insert(st);
}

source.GetAll();
var st1 = source.GetByID(3);
st1.Name = "updatedA3";
source.Update(st1);
source.GetAll();
source.Delete(4);
source.GetAll();

Console.ReadLine();
