using System.Text.RegularExpressions;

namespace kazakov_andrey_kt_43_21.Models
{
  public class Department
  {
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }

    public bool isValidDepartmentName()
    {
      return Regex.Match(DepartmentName, @"\D*").Success;
    }
  }
}
