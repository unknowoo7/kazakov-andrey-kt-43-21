using kazakov_andrey_kt_43_21.Database;
using kazakov_andrey_kt_43_21.Filters.TeacherFilters;
using kazakov_andrey_kt_43_21.Interfaces.TeachersInterfaces;
using kazakov_andrey_kt_43_21.Models;
using Microsoft.EntityFrameworkCore;


namespace kazakov_andrey_kt_43_21.Tests
{
  public class TeachersFiltersIntegrationTests
  {
    private TeacherDbContext GetInMemoryDbContext()
    {
      var options = new DbContextOptionsBuilder<TeacherDbContext>()
          .UseInMemoryDatabase(databaseName: "TeacherDb_Test")
          .Options;
      var context = new TeacherDbContext(options);

      if (!context.Teachers.Any())
      {
        Department departmentMаth = new Department 
        {
          DepartmentId = 1,
          DepartmentName = "Кафедра Математики"
        };

        Department departmentHim = new Department
        {
          DepartmentId = 2,
          DepartmentName = "Кафедра Химии"
        };

        Position positionProfesor = new Position
        {
          PositionId = 1,
          PositionName = "Профессор"
        };

        Position positionAsperant = new Position
        {
          PositionId = 2,
          PositionName = "Аспирант"
        };

        context.Department.AddRange(departmentMаth);
        context.Department.AddRange(departmentHim);
        context.Positions.AddRange(positionProfesor);
        context.Positions.AddRange(positionAsperant);

        context.Teachers.AddRange(
          new Teacher
          {
            FirstName = "Первый",
            LastName = "Первый",
            MiddleName = "Первый",
            DepartmentId = 1,
            PositionId = 1
          },
          new Teacher
          {
            FirstName = "Первый",
            LastName = "Первый",
            MiddleName = "Первый",
            DepartmentId = 2,
            PositionId = 1,
          },
          new Teacher
          {
            FirstName = "Первый",
            LastName = "Первый",
            MiddleName = "Второй",
            DepartmentId = 1,
            PositionId = 1,
          }
        );
        context.SaveChanges();
      }
      return context;
    }

    [Fact]
    public async Task GetTeacherById_Name_OneObject()
    {
      var ctx = GetInMemoryDbContext();
      var teacherService = new ITeacherFilterService(ctx);

      var result = teacherService.GetTeacherById(1);
      Assert.NotNull(result);
      Assert.Equal(1, result.TeachersId);
      Assert.Equal("AA", result.FirstName);
    }

    [Fact]
    public async Task GetTeachersByDataAsync_AA_OneObject()
    {
      var ctx = GetInMemoryDbContext();
      var teacherService = new ITeacherFilterService(ctx);

      TeacherDataFilter filter = new()
      {
        FirstName = "Первый",      
        LastName = "Первый",      
        MiddleName = "Первый" 
      };

      var result = teacherService.GetTeachersByDataAsync(filter);
      Assert.Equal(2, result.Result.Length);
    }

    [Fact]
    public async Task GetTeachersByDepartmentAsync_Math_TwoObject()
    {
      var ctx = GetInMemoryDbContext();
      var teacherService = new ITeacherFilterService(ctx);

      TeacherDepartmentFilter filter = new()
      {
        DepartmentName = "Кафедра Математики"
      };

      var result = teacherService.GetTeachersByDepartmentAsync(filter);
      Assert.Equal(2, result.Result.Length);
    }

    [Fact]
    public async Task GetTeachersByPositionAsync_Profesor_OneObject()
    {
      var ctx = GetInMemoryDbContext();
      var teacherService = new ITeacherFilterService(ctx);

      TeacherPositionFilter filter = new()
      {
        PositionName = "Профессор"
      };

      var result = teacherService.GetTeachersByPositionAsync(filter);
      Assert.Equal(3, result.Result.Length);
    }
  }
}

// пусть кафедра будет называться как группа
