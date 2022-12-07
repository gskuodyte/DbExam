using Common;
using DBAccess;
using DBAccess.Entities;

namespace BusinessLogic;

public class Service
{
    private readonly DbRepository _dbRepository;

    public Service()
    {
        _dbRepository = new DbRepository();
    }

    public Department CreateDepartment(string name)
    {
        return new Department(name);
    }

    public Student CreateStudent(string name, string lastName)
    {
        return new Student(name, lastName);
    }

    public Lecture CreateLecture(string name)
    {
        return new Lecture(name);
    }

    public List<Student> ChooseStudents()
    {
        var studentList = new List<Student>();
        do
        {
            PrintAllStudents();
            Console.WriteLine("Choose student:");
            var studentId = Validator.ParseInt();
            var studentFromDb = _dbRepository.GetStudentById(studentId);
            studentList.Add(studentFromDb);
        } while (Validator.ContinueOrExit());

        return studentList;
    }

    public Student ChooseStudent()
    {
        PrintAllStudents();
        Console.WriteLine("Choose student:");
        var studentId = Validator.ParseInt();
        var studentFromDb = _dbRepository.GetStudentById(studentId);

        return studentFromDb;
    }

    public List<Lecture> ChooseLectures()
    {
        var lectureList = new List<Lecture>();
        do
        {
            PrintAllLectures();
            Console.WriteLine("Choose lecture:");
            var lectureId = Validator.ParseInt();
            var lectureFromDb = _dbRepository.GetLectureById(lectureId);
            lectureList.Add(lectureFromDb);
        } while (Validator.ContinueOrExit());

        return lectureList;
    }

    public void AddDepartment(Department department)
    {
        _dbRepository.AddDepartment(department);
        _dbRepository.SaveChanges();
    }

    public void UpdateDepartment(Department department)
    {
        _dbRepository.AddDepartment(department);
        _dbRepository.UpdateDepartment(department);
    }

    public void AddLectureToDepartment(Department department, Lecture lecture)
    {
        department.Lectures.Add(lecture);
        _dbRepository.UpdateDepartment(department);
    }

    public void AddStudentToDepartment(Department department, Student student)
    {
        department.Students.Add(student);
        _dbRepository.UpdateDepartment(department);
    }

    public void PrintAllStudents()
    {
        var students = _dbRepository.GetAllStudents();

        foreach (var student in students) Console.WriteLine($"{student.Id} {student.Name}, {student.Lastname}");
    }

    public void PrintAllLectures()
    {
        var lectures = _dbRepository.GetAlLectures();
        foreach (var lecture in lectures) Console.WriteLine($"{lecture.Id} {lecture.Name}");
    }

    public void PrintAllDepartments()
    {
        var departments = _dbRepository.GetAllDepartments();
        foreach (var department in departments) Console.WriteLine($"{department.Id} {department.Name}");
    }

    public void GetStudentsFromDepartment(Department department)
    {
        var students = department.Students;
        foreach (var student in students) Console.WriteLine($"{student.Id}  {student.Name},  {student.Lastname}");
    }

    public void GetLecturesFromDepartment(Department department)
    {
        var lectures = department.Lectures;
        foreach (var lecture in lectures) Console.WriteLine($"{lecture.Id}   {lecture.Name}");
    }

    public List<Lecture> GetLecturesByStudent(Student student)
    {
        return _dbRepository.GetAllStudentLectures(student);
    }

    public Department GetDepartmentById(int departmentId)
    {
        return _dbRepository.GetDepartmentById(departmentId);
    }

    public Department AddStudentsToDepartment(Department department, List<Student> students)
    {
        foreach (var student in students) department.Students.Add(student);

        return department;
    }

    public Department AddLecturesToDepartment(Department department, List<Lecture> lectures)
    {
        foreach (var lecture in lectures) department.Lectures.Add(lecture);

        return department;
    }
}