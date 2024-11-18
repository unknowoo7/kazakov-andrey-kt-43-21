using kazakov_andrey_kt_43_21.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kazakov_andrey_kt_43_21.Tests
{
  public class PositionTests
  {
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
