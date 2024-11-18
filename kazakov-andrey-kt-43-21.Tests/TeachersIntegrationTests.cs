using kazakov_andrey_kt_43_21.Database;
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

      if (!context.Teacher.Any())
      {
        context.Teacher.AddRange(
          new Teacher
          {
            TeachersId = 1,
            FirstName = "AA",
            LastName = "AA",
            MiddleName = "AA",
            DepartmentId = 1,
            Department = new Department
            {
              DepartmentId = 1,
              DepartmentName = "Кафедра Математики"
            },
            PositionId = 1,
            Position = new Position
            {
              PositionId = 1,
              PositionName = "Профессор"
            }
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
              PositionName = "Профессор"
            }
          }
        );
        context.SaveChanges();
      }
      return context;
    }

    [Fact]
    public async Task GetTeachersByDepartmentAsync_IT_TwoObject()
    {
      var ctx = GetInMemoryDbContext();
      var teacherService = new ITeacherFilterService(ctx);

      var result = teacherService.GetTeacherById(1);
      Assert.NotNull(result);
      Assert.Equal(1, result.TeachersId);
      Assert.Equal("AA", result.FirstName);
    }
  }
}

// пусть кафедра будет называться как группа