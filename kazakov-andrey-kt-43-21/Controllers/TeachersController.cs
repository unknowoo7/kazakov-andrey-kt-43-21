using kazakov_andrey_kt_43_21.Dto;
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
    public async Task<IActionResult> AddTeacher(TeacherDto teacher)
    {
      Position position = _positionService.GetPositionById(teacher.positionId);
      Department department = _departmentService.GetDepartmentById(teacher.departmentId);

      Teacher newTeacher = new Teacher { FirstName = teacher.FirstName, LastName = teacher.LastName, MiddleName = teacher.MiddleName };

      newTeacher.PositionId = teacher.positionId;
      newTeacher.Position = position;
      newTeacher.DepartmentId = teacher.departmentId;
      newTeacher.Department = department;

      return Ok(await _teacherService.AddTeacher(newTeacher));
    }


    [HttpPut("{teacherId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateTeacher(int teacherId, TeacherDto updatedTeacher)
    {
      if (updatedTeacher == null)
        return BadRequest(ModelState);

      if (!_teacherService.TeacherExists(teacherId))
        return NotFound();

      if (!ModelState.IsValid)
        return BadRequest();

      Position position = _positionService.GetPositionById(updatedTeacher.positionId);
      Department department = _departmentService.GetDepartmentById(updatedTeacher.departmentId);

      Teacher teacher = new Teacher { 
        Department = department,
        Position = position,
        FirstName = updatedTeacher.FirstName,
        LastName = updatedTeacher.LastName,
        MiddleName = updatedTeacher.MiddleName,
        DepartmentId = updatedTeacher.departmentId,
        PositionId = updatedTeacher.positionId
      };

      if (!_teacherService.UpdateTeacher(teacher))
      {
        ModelState.AddModelError("", "Something went wrong updating teacher");
        return StatusCode(500, ModelState);
      }

      return NoContent();
    }


    [HttpDelete("{teacherId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteOwner(int teacherId)
    {
      if (!_teacherService.TeacherExists(teacherId))
      {
        return NotFound();
      }

      var teacherToDelete = _teacherService.GetTeacherById(teacherId);

      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      if (!_teacherService.DeleteTeacher(teacherToDelete))
      {
        ModelState.AddModelError("", "Something went wrong deleting teacher");
      }

      return NoContent();
    }
  }
}
