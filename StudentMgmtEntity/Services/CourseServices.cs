using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentMgmtEntity.Data;
using StudentMgmtEntity.Models;

namespace StudentMgmtEntity.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CourseServices(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Course> AddCourse(CourseDto request)
        {
            if (await _context.Courses.AnyAsync(c => c.Name == request.Name))
            {
                return null;
            }
            var course = _mapper.Map<Course>(request);
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;

        }

        public async Task<Course> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return null;
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            var courses = await _context.Courses.ToListAsync();
            if (courses == null) return null;
            return courses;
        }

        public async Task<Course> GetOneCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return null;
            return course;
        }

        public async Task<Course> UpdateCourse(int id, CourseDto request)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return null;
            course.Name = request.Name;
            course.Teacher = request.Teacher;
            await _context.SaveChangesAsync();
            return course;
        }
    }
}
