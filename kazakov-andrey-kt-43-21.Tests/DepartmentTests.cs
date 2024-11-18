using kazakov_andrey_kt_43_21.Models;
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
    [Fact]
    public void IsValidDepartmentName_KT4321_True()
    {
      //arrange
      var test = new Department
      {
        DepartmentName = "Химия"
      };

      //act
      var result = test.isValidDepartmentName();

      //assert
      Assert.True(result);
    }
  }
}
