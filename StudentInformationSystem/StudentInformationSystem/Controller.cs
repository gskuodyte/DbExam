using BusinessLogic;
using Common;
using DBAccess.Entities;

namespace StudentInformationSystem;

public class Controller
{
    private readonly Service _service;

    public Controller()
    {
        _service = new Service();
    }

    public void ShowMainMenu()
    {
        for (var i = 1; i <= 8; i++) Console.WriteLine($"[{i}] Task {i}");

        var task = Validator.ParseInt();

        OptionsMenu(task);
    }

    public void OptionsMenu(int numOfTask)
    {
        switch (numOfTask)
        {
            case 1:
                CreateDepartment();
                goto default;
            case 2:
                EditDepartment();
                goto default;
            case 3:
                CreateLectureAndAttachToDepartment();
                goto default;
            case 4:
                CreateStudentAndAttachToDepartment();
                goto default;
            case 5:
                MoveStudentToAnotherDepartment();
                goto default;
            case 6:
                PrintAllStudentsFromDepartment();
                goto default;
            case 7:
                PrintAllLecturesFromDepartment();
                goto default;
            case 8:
                DisplayLecturesByStudent();
                goto default;
            default:
                Console.ReadKey();
                Console.Clear();
                ShowMainMenu();
                break;
        }
    }
    
    public void CreateDepartment()
    {
        Console.WriteLine("Choose Department name:");
        var name = Console.ReadLine();
        if (name == null) return;
        var department = _service.CreateDepartment(name);

        AddStudentsAndLecturesToNewDepartment(department);
    }

    public void AddStudentsAndLecturesToNewDepartment(Department department)
    {
        department.Students = ChooseStudents();
        department.Lectures = ChooseLectures();

        _service.AddDepartment(department);
    }

    public List<Student> ChooseStudents()
    {
        return _service.ChooseStudents();
    }

    public Student ChooseStudent()
    {
        return _service.ChooseStudent();
    }

    public List<Lecture> ChooseLectures()
    {
        return _service.ChooseLectures();
    }

    public void EditDepartment()
    {
        var department = ChooseDepartment();
        AddStudentsAndLecturesToDepartment(department);
    }

    public Department ChooseDepartment()
    {
        Console.WriteLine("Choose Department Id:");
        _service.PrintAllDepartments();
        var departmentId = Validator.ParseInt();
        var department = _service.GetDepartmentById(departmentId);
        return department;
    }

    public void AddStudentsAndLecturesToDepartment(Department department)
    {
        var students = ChooseStudents();
        var lectures = ChooseLectures();

        var studentDepartment = _service.AddStudentsToDepartment(department, students);
        var fullDepartment = _service.AddLecturesToDepartment(studentDepartment, lectures);


        _service.UpdateDepartment(fullDepartment);
    }

    public void CreateLectureAndAttachToDepartment()
    {
        Console.WriteLine("Choose Lecture name:");
        var name = Console.ReadLine();
        if (name == null) return;
        var lecture = _service.CreateLecture(name);
        var department = ChooseDepartment();

        _service.AddLectureToDepartment(department, lecture);
    }

    public void CreateStudentAndAttachToDepartment()
    {
        Console.WriteLine("Choose Student name:");
        var name = Console.ReadLine();
        Console.WriteLine("Choose Student lastname:");
        var lastname = Console.ReadLine();

        if (name == null) return;
        if (lastname == null) return;

        var student = _service.CreateStudent(name, lastname);

        var department = ChooseDepartment();

        _service.AddStudentToDepartment(department, student);
    }

    public void MoveStudentToAnotherDepartment()
    {
        Console.WriteLine("Choose Student Id:");
        var students = ChooseStudents();

        var department = ChooseDepartment();

        _service.AddStudentsToDepartment(department, students);
        _service.UpdateDepartment(department);
    }

    public void PrintAllStudentsFromDepartment()
    {
        var department = ChooseDepartment();

        _service.GetStudentsFromDepartment(department);
    }

    public void PrintAllLecturesFromDepartment()
    {
        var department = ChooseDepartment();

        _service.GetLecturesFromDepartment(department);
    }

    public void DisplayLecturesByStudent()
    {
        var student = ChooseStudent();

        var lectures = _service.GetLecturesByStudent(student);
        foreach (var item in lectures) Console.WriteLine(item.Name);
    }
}