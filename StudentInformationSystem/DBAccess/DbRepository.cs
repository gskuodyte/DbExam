using DBAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBAccess;

public class DbRepository 
{
    private readonly AccessDbContext _dbContext;
    
    public DbRepository()
    {
        _dbContext = new AccessDbContext();
    }

    public List<Student> GetAllStudents()
    {
        return _dbContext.Students.ToList();
    }

    public List<Lecture> GetAlLectures()
    {
        return _dbContext.Lectures.ToList();
    }

    public List<Department> GetAllDepartments()
    {
        return _dbContext.Departments.ToList();
    }

    public List<Lecture>? GetAllStudentLectures(Student student)
    {
        var department = _dbContext.Departments.Include(d => d.Lectures)
            .FirstOrDefault(s => s.Id == student.Department.Id);
        return department?.Lectures;
    }

    public void AddDepartment(Department department)
    {
        _dbContext.Departments.Add(department);
    }

    public Department GetDepartmentById(int id)
    {
        return _dbContext.Departments.Include(d => d.Lectures).Include(d => d.Students).FirstOrDefault(d => d.Id == id)!;
    }

    public Student GetStudentById(int id)
    {
        return _dbContext.Students.Include(s => s.Department.Lectures).FirstOrDefault(s => s.Id == id)!;
    }

    public Lecture GetLectureById(int id)
    {
        return _dbContext.Lectures.Include(s => s.Departments).FirstOrDefault(l => l.Id == id)!;
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }

    public void UpdateDepartment(Department department)
    {
        _dbContext.Update(department);
        _dbContext.SaveChanges();
    }
}