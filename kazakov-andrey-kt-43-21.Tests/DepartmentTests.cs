using kazakov_andrey_kt_43_21.Database;
using kazakov_andrey_kt_43_21.Interfaces.DepartmentInterfaces;
using kazakov_andrey_kt_43_21.Interfaces.PositionInterfaces;
using kazakov_andrey_kt_43_21.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace kazakov_andrey_kt_43_21.Tests
{
  public class DepartmentTests
  {
    private TeacherDbContext GetInMemoryDbContext()
    {
      var options = new DbContextOptionsBuilder<TeacherDbContext>()
          .UseInMemoryDatabase(databaseName: "TeacherDb_Test")
          .Options;
      var context = new TeacherDbContext(options);
      if (!context.Department.Any())
      {
        Department departmentMath = new Department
        {
          DepartmentId = 1,
          DepartmentName = "Кафедра Математики"
        };

        context.Department.AddRange(departmentMath);
        context.SaveChanges();
      }
      return context;
    }

    [Fact]
    public async Task GetDepartmentById_1_OneObject()
    {
      var ctx = GetInMemoryDbContext();
      var service = new DepartmentService(ctx);

      var result = service.GetDepartmentById(1);
      Assert.NotNull(result);
      Assert.Equal(1, result.DepartmentId);
      Assert.Equal("Кафедра Математики", result.DepartmentName);
    }

    [Fact]
    public async Task AddDepartment_New_True()
    {
      var ctx = GetInMemoryDbContext();
      var service = new DepartmentService(ctx);

      Department departmentHimii = new Department
      {
        DepartmentId = 2,
        DepartmentName = " Химии"
      };

      var result = service.AddDepartment(departmentHimii);
      Assert.NotNull(result);
    }


    [Fact]
    public void IsValidDepartmentName_Math_True()
    {
      //arrange
      var test = new Department
      {
        DepartmentName = "Ка Математики"
      };

      //act
      var result = test.isValidDepartmentName();

      //assert
      Assert.True(result);
    }
  }
}
