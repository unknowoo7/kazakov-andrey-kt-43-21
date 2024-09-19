using kazakov_andrey_kt_43_21.Models;
using System.Text.RegularExpressions;

namespace kazakov_andrey_kt_43_21.Tests
{
  public class UnitTest1
  {
    [Fact]
    public void IsValidDepartmentName_IT_True()
    {
      var testDepartment = new Department
      {
        DepartmentName = "Информационные технологии",
      };

      var result = testDepartment.isValidDepartmentName();

      Assert.True(result);
    }
  }
}