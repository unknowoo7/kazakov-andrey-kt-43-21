using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace kazakov_andrey_kt_43_21.Models
{
  public class Department
  {
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } 
    public int? TeacherHeaderId { get; set; }
    [JsonIgnore]
    public Teacher? Teacher { get; set; }  

    public bool isValidDepartmentName()
    {
      //return Regex.Match(DepartmentName, @"(.*[А-ЯЁ][а-яё]+)*(\s[А-ЯЁ][а-яё]*)?$").Success;
      return Regex.Match(DepartmentName, @"^[А-ЯЁ][а-яё](\S+)?\s[А-ЯЁ][а-яё]+$").Success;
    }
  }
}
