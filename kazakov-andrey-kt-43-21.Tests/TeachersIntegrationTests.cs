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
    private TeacherDbContext GetInMemoryDbContext()
    {
      var options = new DbContextOptionsBuilder<TeacherDbContext>()
          .UseInMemoryDatabase(databaseName: "TeacherDb_Test")
          .Options;
      var context = new TeacherDbContext(options);
      return context;
    }

    [Fact]
    public async Task AddTeacher_New_True()
    {
      var ctx = GetInMemoryDbContext();
      var service = new TeacherService(ctx);

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

      var teacher = new Teacher
      {
        TeachersId = 1,
        FirstName = "AA",
        LastName = "AA",
        MiddleName = "AA",
        DepartmentId = 1,
        Department = departmentMeth,
        PositionId = 1,
        Position = positionProfesor
      };
    
      var result = service.AddTeacher(teacher);
      Assert.NotNull(result);
    }
  }
}
