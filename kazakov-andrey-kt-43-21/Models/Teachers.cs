namespace kazakov_andrey_kt_43_21.Models
{
  public class Teachers
  {
    public string TeachersId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }

    public string DepartmentId { get; set; }
    public Department Department { get; set; }

    public string PositionId { get; set; }
    public Position Position { get; set; }
  }
}
