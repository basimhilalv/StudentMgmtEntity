using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMgmtEntity.Models;
using StudentMgmtEntity.Services;

namespace StudentMgmtEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;
        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _studentServices.GetOneStudent(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudent()
        {
            var student = await _studentServices.GetStudents();
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> AddStudent(StudentDto request)
        {
            var created = await _studentServices.AddStudent(request);
            if(created == null)
            {
                return BadRequest();
            }
            return Created();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateStudent(int id, StudentDto request)
        {
            var updated = await _studentServices.UpdateStudent(id, request);
            if (updated == null) return BadRequest();
            return NoContent();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var deleted = await _studentServices.DeleteStudent(id);
            if (deleted == null) return BadRequest();
            return NoContent();
        }
    }
}
