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
        public Task<ActionResult<Course>> getCourse(int id)
        {

        }
    }
}
