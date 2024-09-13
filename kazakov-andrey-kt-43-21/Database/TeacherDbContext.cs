using kazakov_andrey_kt_43_21.Database.Configurations;
using kazakov_andrey_kt_43_21.Models;
using Microsoft.EntityFrameworkCore;

namespace kazakov_andrey_kt_43_21.Database
{
  public class TeacherDbContext : DbContext
  {

    DbSet<Teacher> Teachers { get; set; }
    DbSet<Department> Department { get; set; }
    DbSet<Position> Positions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new TeachersConfiguration());
      modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
      modelBuilder.ApplyConfiguration(new PositionConfiguration());
    }

    public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
    {

    }
  }
}
