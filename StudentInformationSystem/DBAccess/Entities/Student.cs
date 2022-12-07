using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBAccess.Entities;

public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }
    public string Lastname { get; set; }
    public Department Department { get; set; }
    public Student(string name, string lastname)
    {
        Name = name;
        Lastname = lastname;
        Department = new Department();
    }
}