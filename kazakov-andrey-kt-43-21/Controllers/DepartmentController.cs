using kazakov_andrey_kt_43_21.Interfaces.DepartmentInterfaces;
using kazakov_andrey_kt_43_21.Interfaces.StudentsInterfaces;
using kazakov_andrey_kt_43_21.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


/**
 5)	Добавление/изменение удаление кафедр (удаление см. начало документа) 
    при удалении кафедры, удаляются и привязанные к кафедре преподаватели
*/


namespace kazakov_andrey_kt_43_21.Controllers
{

  [ApiController]
  [Route("[controller]")]
  public class DepartmentController : Controller
  {

    private readonly ITeacherService _teacherService;
    private readonly IDepartmentService _departmentService;

    public DepartmentController(ITeacherService teacherService, IDepartmentService departmentService)
    {
      _teacherService = teacherService;
      _departmentService = departmentService;
    }

    [HttpPost("add")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> AddDeparment([FromBody] Department department)
    {
      return Ok(await _departmentService.AddDepartment(department));
    }

    [HttpPut("{teacherId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateDepartment(int departmentId, Department department) 
    { 
      if (department == null)
      {
        return BadRequest(ModelState);
      }

      if (!_departmentService.DepartmentExists(departmentId))
      {
        return NotFound();
      }

      if (!ModelState.IsValid) 
      { 
        return BadRequest();
      }

      if (!_departmentService.UpdateDepartment(department))
      {
        ModelState.AddModelError("", "Something went wrong updating department");
        return StatusCode(500, ModelState);
      }

      return NoContent();
    }
  }
}
