using System.Text.RegularExpressions;

namespace kazakov_andrey_kt_43_21.Models
{
  public class Position
  {
    public int PositionId { get; set; }

    public string PositionName { get; set; }
    public bool isValidPositionName()
    {
      return Regex.Match(PositionName, @"^[А-ЯЁ][а-яё]*(\s[а-яё]+)*$").Success;
    }
  }
}
