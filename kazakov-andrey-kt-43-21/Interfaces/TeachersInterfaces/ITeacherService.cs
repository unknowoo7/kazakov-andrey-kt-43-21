using kazakov_andrey_kt_43_21.Database;
using kazakov_andrey_kt_43_21.Filters.TeacherFilters;
using kazakov_andrey_kt_43_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

/*
 2)Получение списка преподавателей (учесть фильтрацию по кафедре, по степени, по должности)
 5)Добавление/изменение удаление кафедр (удаление см. начало документа) при удалении кафедры, 
   удаляются и привязанные к кафедре преподаватели 
*/


namespace kazakov_andrey_kt_43_21.Interfaces.StudentsInterfaces
{
  public interface ITeacherService
  {
    public Task<Teacher[]> GetTeachersByDataAsync(TeacherDataFilter filter, CancellationToken cancellationToken);
    public Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken);
    public Task<Teacher[]> GetTeachersByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken);
    public Task<Teacher> AddTeacher(Teacher teacher);
    public bool TeacherExists(int teacherId);
    public bool UpdateTeacher(Teacher teacher);
  }

  public class TeacherService : ITeacherService
  {
    private readonly TeacherDbContext _dbContext;

    public TeacherService(TeacherDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<Teacher> AddTeacher(Teacher teacher)
    {
      _dbContext.Add(teacher);
      await _dbContext.SaveChangesAsync();
      return teacher;
    }

    public Task<Teacher[]> GetTeachersByDataAsync(TeacherDataFilter filter, CancellationToken cancellationToken = default)
    {
      var teacher = _dbContext.Set<Teacher>().Where(w => w.FirstName == filter.FirstName && w.LastName == filter.LastName && w.MiddleName == filter.MiddleName).ToArrayAsync(cancellationToken);

      return teacher;
    }

    public async Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default)
    {
      var teacher = await _dbContext.Set<Teacher>().Where(w => w.Department.DepartmentName == filter.DepartmentName).ToArrayAsync(cancellationToken);

      return teacher;
    }

    public Task<Teacher[]> GetTeachersByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken = default)
    {
      var teacher = _dbContext.Set<Teacher>().Where(w => w.Position.PositionName == filter.PositionName).ToArrayAsync(cancellationToken);

      return teacher;
    }

    public bool TeacherExists(int teacherId)
    {
      return _dbContext.Teachers.Any(t => t.TeachersId == teacherId);
    }

    public bool UpdateTeacher(Teacher teacher)
    {
      _dbContext.Update(teacher);
      return _dbContext.SaveChanges() > 0;
    }
  }
}
