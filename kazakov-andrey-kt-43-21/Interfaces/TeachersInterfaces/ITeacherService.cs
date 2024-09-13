using kazakov_andrey_kt_43_21.Database;
using kazakov_andrey_kt_43_21.Filters.TeacherFilters;
using kazakov_andrey_kt_43_21.Models;
using Microsoft.EntityFrameworkCore;

namespace kazakov_andrey_kt_43_21.Interfaces.StudentsInterfaces
{
  public interface ITeacherService
  {
    public Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken);
  }

  public class TeacherService : ITeacherService
  {
    private readonly TeacherDbContext _dbContext;

    public TeacherService(TeacherDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default)
    {
      var teacher = _dbContext.Set<Teacher>().Where(w => w.Department.DepartmentName == filter.DepartmentName).ToArrayAsync(cancellationToken);

      return teacher;
    }
  }
}
