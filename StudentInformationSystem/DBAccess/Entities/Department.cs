using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBAccess.Entities;

public class Department
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }
    public List<Student> Students { get; set; }
    public List<Lecture> Lectures { get; set; }

    public Department(){}
    public Department(string name)
    {
        Name = name;
        Students = new List<Student>();
        Lectures = new List<Lecture>();
    }
}