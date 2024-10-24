using kazakov_andrey_kt_43_21.Database;
using kazakov_andrey_kt_43_21.Filters.TeacherFilters;
using kazakov_andrey_kt_43_21.Models;


/**
 5)	Добавление/изменение удаление кафедр (удаление см. начало документа) 
    при удалении кафедры, удаляются и привязанные к кафедре преподаватели
*/


namespace kazakov_andrey_kt_43_21.Interfaces.DepartmentInterfaces
{
  public interface IDepartmentService 
  {
    public Task<Department> DeleteDepartment(TeacherDepartmentFilter department, CancellationToken cancellationToken);
    public Department GetDepartmentById(int id);
    public ICollection<Department> GetDepartment();
    public Task<Department> AddDepartment (Department department);
    public bool DepartmentExists (int deparmentId);
    public bool UpdateDepartment (Department department);
    public bool DeleteDepartment (Department department);
  }

  public class DepartmentService : IDepartmentService
  {
    private readonly TeacherDbContext _dbContext;

    public DepartmentService(TeacherDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public ICollection<Department> GetDepartment()
    {
      return _dbContext.Department.ToList();
    }

    public Department GetDepartmentById(int id)
    {
      return _dbContext.Department.Where(d => d.DepartmentId == id).FirstOrDefault();
    }

    public Task<Department> DeleteDepartment(TeacherDepartmentFilter department, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<Department> AddDepartment(Department department)
    {
      _dbContext.Add(department);
      await _dbContext.SaveChangesAsync();
      return department;
    }

    public bool DepartmentExists(int deparmentId)
    {
      return _dbContext.Department.Any(d => d.DepartmentId == deparmentId);
    }

    public bool UpdateDepartment(Department department)
    {
      _dbContext.Update(department);
      return _dbContext.SaveChanges() > 0;
    }

    public bool DeleteDepartment(Department department)
    {
      _dbContext.Remove(department);
      return _dbContext.SaveChanges() > 0;
    }
  }
}
