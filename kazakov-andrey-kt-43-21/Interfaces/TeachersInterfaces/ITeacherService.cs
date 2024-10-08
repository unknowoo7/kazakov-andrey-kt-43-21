﻿using kazakov_andrey_kt_43_21.Database;
using kazakov_andrey_kt_43_21.Filters.TeacherFilters;
using kazakov_andrey_kt_43_21.Models;
using Microsoft.EntityFrameworkCore;

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
  }

  public class TeacherService : ITeacherService
  {
    private readonly TeacherDbContext _dbContext;

    public TeacherService(TeacherDbContext dbContext)
    {
      _dbContext = dbContext;
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
  }
}
