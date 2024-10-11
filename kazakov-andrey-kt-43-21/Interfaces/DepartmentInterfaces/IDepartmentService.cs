using kazakov_andrey_kt_43_21.Database;
using kazakov_andrey_kt_43_21.Filters.TeacherFilters;
using kazakov_andrey_kt_43_21.Models;

namespace kazakov_andrey_kt_43_21.Interfaces.DepartmentInterfaces
{
  public interface IDepartmentService 
  {
    public Task<Department> DeleteDepartment(TeacherDepartmentFilter department, CancellationToken cancellationToken);
    public Department GetDepartmentById(int id);
  }

  public class DepartmentService : IDepartmentService
  {
    private readonly TeacherDbContext _dbContext;

    public DepartmentService(TeacherDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public Department GetDepartmentById(int id)
    {
      return _dbContext.Department.Where(d => d.DepartmentId == id).FirstOrDefault();
    }

    public Task<Department> DeleteDepartment(TeacherDepartmentFilter department, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
