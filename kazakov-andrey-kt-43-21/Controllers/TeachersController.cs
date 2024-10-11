using kazakov_andrey_kt_43_21.Filters.TeacherFilters;
using kazakov_andrey_kt_43_21.Interfaces.StudentsInterfaces;
using kazakov_andrey_kt_43_21.Models;
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

    [HttpPost("GetTeachersByDataAsync")]
    public async Task<IActionResult> GetTeachersByDataAsync(TeacherDataFilter filter, CancellationToken cancellationToken = default)
    {
      var teachers = await _teacherService.GetTeachersByDataAsync(filter, cancellationToken);
      return Ok(teachers);
    }

    [HttpPost("GetTeachersByDepartmentAsync")]
    public async Task<IActionResult> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default)
    {
      var teachers = await _teacherService.GetTeachersByDepartmentAsync(filter, cancellationToken);
      return Ok(teachers);
    }

    [HttpPost("GetTeachersByPosition")]
    public async Task<IActionResult> GetTeachersByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken = default)
    {
      var teachers = await _teacherService.GetTeachersByPositionAsync(filter, cancellationToken);
      return Ok(teachers);
    }

    [HttpPost("add")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> AddTeacher([FromQuery] int n,  Teacher teacher)
    {
      return Ok(await _teacherService.AddTeacher(teacher));
    }
  }
}
