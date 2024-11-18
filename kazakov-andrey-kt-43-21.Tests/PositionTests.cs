using kazakov_andrey_kt_43_21.Database;
using kazakov_andrey_kt_43_21.Interfaces.PositionInterfaces;
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
  public class PositionTests
  {
    private TeacherDbContext GetInMemoryDbContext()
    {
      var options = new DbContextOptionsBuilder<TeacherDbContext>()
          .UseInMemoryDatabase(databaseName: "TeacherDb_Test")
          .Options;
      var context = new TeacherDbContext(options);
      if (!context.Teachers.Any())
      {
        Position positionProfesor = new Position
        {
          PositionId = 1,
          PositionName = "Профессор"
        };

        context.Positions.AddRange(positionProfesor);
        context.SaveChanges();
      }
      return context;
    }

    [Fact]
    public async Task GetPositionById_1_OneObject()
    {
      var ctx = GetInMemoryDbContext();
      var service = new PositionService(ctx);

      var result = service.GetPositionById(1);
      Assert.NotNull(result);
      Assert.Equal(1, result.PositionId);
      Assert.Equal("Профессор", result.PositionName);
    }

    [Fact]
    public void IsValidPositionName_KT4321_True()
    {
      //arrange
      var test = new Position
      {
        PositionName = "Химия"
      };

      //act
      var result = test.isValidPositionName();

      //assert
      Assert.True(result);
    }
  }
}
