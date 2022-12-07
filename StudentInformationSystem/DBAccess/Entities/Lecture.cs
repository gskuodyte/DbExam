using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBAccess.Entities;

public class Lecture
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }
    public List<Department> Departments { get; set; }
    public Lecture(string name)
    {
        Name = name;
        Departments = new List<Department>();
    }
}