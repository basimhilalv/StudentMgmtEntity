using StudentMgmtEntity.Models;

namespace StudentMgmtEntity.Services
{
    public interface ICourseServices
    {
        public Task<IEnumerable<Course>> GetCourses();
        public Task<Course> GetOneCourse(int id);
        public Task<Course> AddCourse(CourseDto request);
        public Task<Course> UpdateCourse(int id, CourseDto request);
        public Task<Course> DeleteCourse(int id);
    }
}
