using AutoMapper;
using StudentMgmtEntity.Models;

namespace StudentMgmtEntity.Mappings
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
        }

    }
}
