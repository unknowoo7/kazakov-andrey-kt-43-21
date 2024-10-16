using kazakov_andrey_kt_43_21.Filters.TeacherFilters;
using kazakov_andrey_kt_43_21.Interfaces.DepartmentInterfaces;
using kazakov_andrey_kt_43_21.Interfaces.PositionInterfaces;
using kazakov_andrey_kt_43_21.Interfaces.StudentsInterfaces;
using kazakov_andrey_kt_43_21.Models;
using Microsoft.AspNetCore.Mvc;

namespace kazakov_andrey_kt_43_21.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TeachersController : Controller
  {
    private readonly IPositionService _positionService;
    private readonly IDepartmentService _departmentService;
    private readonly ITeacherService _teacherService;

    public TeachersController(IPositionService positionService, IDepartmentService departmentService, ITeacherService teacherService)
    {
      _positionService = positionService;
      _teacherService = teacherService;
      _departmentService = departmentService;
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
    public async Task<IActionResult> AddTeacher([FromQuery] int departmentId, [FromQuery] int positionId, Teacher teacher)
    {
      Position position = _positionService.GetPositionById(positionId);
      Department department = _departmentService.GetDepartmentById(departmentId);

      teacher.Position = position;
      teacher.Department = department;
      return Ok(await _teacherService.AddTeacher(teacher));
    }
  }
}
