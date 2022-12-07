using DBAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBAccess;

public class AccessDbContext : DbContext
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StudentInformation;Trusted_Connection=True;");
    }
}