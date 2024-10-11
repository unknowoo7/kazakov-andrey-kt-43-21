using kazakov_andrey_kt_43_21.Interfaces.StudentsInterfaces;

namespace kazakov_andrey_kt_43_21.Controllers
{
  public class DepartmentController
  {

    private readonly ITeacherService _teacherService;

    public DepartmentController(ITeacherService teacherService)
    {
      _teacherService = teacherService;
    }
  }
}
