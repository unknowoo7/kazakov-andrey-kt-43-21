using kazakov_andrey_kt_43_21.Filters.TeacherFilters;
using kazakov_andrey_kt_43_21.Interfaces.StudentsInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace kazakov_andrey_kt_43_21.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TeachersController : Controller
  {

    private readonly ILogger<TeachersController> _logger;
    private readonly ITeacherService _teacherService;

    public TeachersController(ILogger<TeachersController> logger, ITeacherService teacherService)
    {
      _logger = logger;
      _teacherService = teacherService;
    }

    [HttpPost(Name = "GetTeachersByData")]
    public async Task<IActionResult> GetTeachersByDataAsync(TeacherDataFilter filter, CancellationToken cancellationToken = default)
    {
      var teachers = await _teacherService.GetTeachersByDataAsync(filter, cancellationToken);
      return Ok(teachers);
    }

    [HttpPost(Name = "GetTeachersByDepartment")]
    public async Task<IActionResult> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default)
    {
      var teachers = await _teacherService.GetTeachersByDepartmentAsync(filter, cancellationToken);
      return Ok(teachers);
    }

    [HttpPost(Name = "GetTeachersByPosition")]
    public async Task<IActionResult> GetTeachersByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken = default)
    {
      var teachers = await _teacherService.GetTeachersByPositionAsync(filter, cancellationToken);
      return Ok(teachers);
    }
  }
}
