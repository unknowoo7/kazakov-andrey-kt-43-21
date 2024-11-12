using kazakov_andrey_kt_43_21.Database;
using kazakov_andrey_kt_43_21.Interfaces.TeachersInterfaces;
using kazakov_andrey_kt_43_21.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kazakov_andrey_kt_43_21.Tests
{
  public class TeachersIntegrationTests
  {
    public readonly DbContextOptions<TeacherDbContext> _dbContextOptions;
    
    public TeachersIntegrationTests()
    {
      _dbContextOptions = new DbContextOptionsBuilder<TeacherDbContext>()
        .UseInMemoryDatabase(databaseName: "teacher_db")
        .Options;
    }

    [Fact]
    public async Task GetTeachersByDepartmentAsync_IT_TwoObject()
    {
      var ctx = new TeacherDbContext(_dbContextOptions);
      var teacherService = new TeacherService(ctx);
      var departments = new List<Department>
      {
        new Department
        {
          DepartmentName = "Математика"
        },
        new Department
        {
          DepartmentName = "Химия"
        }
      };

      await ctx.Set<Department>().AddRangeAsync(departments);

      var teachers = new List<Teacher>
      {
        new Teacher
        {
          FirstName = "Иван",
          LastName = "Иванов",
          MiddleName = "Иванович",
          DepartmentId = 1,
        },
        new Teacher
        {
          FirstName = "Петр",
          LastName = "Петров",
          MiddleName = "Петрович",
          DepartmentId = 1,
        }
      };

      await ctx.Set<Teacher>().AddRangeAsync(teachers);

      await ctx.SaveChangesAsync();

      var filter = new Filters.TeacherFilters.TeacherDepartmentFilter
      {
        DepartmentName = "Математика"
      };

      var teachersResult = await teacherService.GetTeachersByDepartmentAsync(filter, CancellationToken.None);

      Assert.Equal(2, teachersResult.Length);
    }
  }
}
