using kazakov_andrey_kt_43_21.Database;
using kazakov_andrey_kt_43_21.Filters.TeacherFilters;
using kazakov_andrey_kt_43_21.Interfaces.TeachersInterfaces;
using kazakov_andrey_kt_43_21.Models;
using Microsoft.EntityFrameworkCore;


namespace kazakov_andrey_kt_43_21.Tests
{
  public class TeachersIntegrationTests
  {
    private TeacherDbContext GetInMemoryDbContext()
    {
      var options = new DbContextOptionsBuilder<TeacherDbContext>()
          .UseInMemoryDatabase(databaseName: "TeacherDb_Test")
          .Options;
      var context = new TeacherDbContext(options);

      if (!context.Teachers.Any())
      {
        Department departmentMeth = new Department 
        {
          DepartmentId = 1,
          DepartmentName = "Кафедра Математики"
        };

        Position positionProfesor = new Position
        {
          PositionId = 1,
          PositionName = "Профессор"
        };

        Position positionAsperant = new Position
        {
          PositionId = 3,
          PositionName = "Асперант"
        };

        context.Teachers.AddRange(
          new Teacher
          {
            TeachersId = 1,
            FirstName = "AA",
            LastName = "AA",
            MiddleName = "AA",
            DepartmentId = 1,
            Department = departmentMeth,
            PositionId = 1,
            Position = positionProfesor
          },
          new Teacher
          {
            TeachersId = 2,
            FirstName = "PP",
            LastName = "PP",
            MiddleName = "PP",
            DepartmentId = 2,
            Department = new Department
            {
              DepartmentId = 2,
              DepartmentName = "Кафедра Физика"
            },
            PositionId = 2,
            Position = new Position
            {
              PositionId = 2,
              PositionName = "Преподаватель"
            }
          },
          new Teacher
          {
            TeachersId = 3,
            FirstName = "СС",
            LastName = "СС",
            MiddleName = "СС",
            DepartmentId = 1,
            Department = departmentMeth,
            PositionId = 3,
            Position = positionAsperant
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
        FirstName = "AA",      
        LastName = "AA",      
        MiddleName = "AA" 
      };

      var result = teacherService.GetTeachersByDataAsync(filter);
      Assert.Equal(1, result.Result.Length);
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
      Assert.Equal(1, result.Result.Length);
    }
  }
}

// пусть кафедра будет называться как группа