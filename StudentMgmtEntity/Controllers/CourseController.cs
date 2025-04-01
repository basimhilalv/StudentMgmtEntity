using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentMgmtEntity.Models;
using StudentMgmtEntity.Services;

namespace StudentMgmtEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public readonly ICourseServices _courseServices;
        public CourseController(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> getCourse(int id)
        {
            var course = await _courseServices.GetOneCourse(id);
            if (course == null) return NotFound();
            return Ok(course);

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Course>>> getCourses()
        {
            var courses = await _courseServices.GetCourses();
            if (courses == null) return NotFound();
            return Ok(courses);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> createCourse(CourseDto request)
        {
            var created = await _courseServices.AddCourse(request);
            if (created == null) return BadRequest();
            return NoContent();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> updateCourse(int id, CourseDto request)
        {
            var updated = await _courseServices.UpdateCourse(id, request);
            if (updated == null) return NotFound();
            return NoContent();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> deleteCourse(int id)
        {
            var deleted = await _courseServices.DeleteCourse(id);
            if (deleted == null) return NotFound();
            return NoContent();
        }
    }
}
