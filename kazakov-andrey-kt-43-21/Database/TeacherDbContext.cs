using Microsoft.EntityFrameworkCore;

namespace kazakov_andrey_kt_43_21.Database
{
  public class TeacherDbContext : DbContext
  {
    public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
    {
    }
  }
}
