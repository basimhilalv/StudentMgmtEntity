using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentMgmtEntity.Data;
using StudentMgmtEntity.Models;

namespace StudentMgmtEntity.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public StudentServices(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentResponse>> GetSearch(string searchword)
        {
            var search = _context.Students.Where(s => s.Name.StartsWith(searchword));
            var searchMap = _mapper.Map<IEnumerable<StudentResponse>>(search);
            if (search == null) return null;
            return searchMap;
        }
        public async Task<Student> AddStudent(StudentDto request)
        {
            if(await _context.Students.AnyAsync(s => s.Email == request.Email))
            {
                return null;
            }
            var student = _mapper.Map<Student>(request);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;

        }

        public async Task<Student> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return null;
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;

        }

        public async Task<Student> GetOneStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return null;
            return student;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var students = await _context.Students.ToListAsync();
            return students;
        }

        public async Task<Student> UpdateStudent(int id, StudentDto request)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return null;
            student.DOB = request.DOB;
            student.Age = request.Age;
            student.Name = request.Name;
            student.Phone = request.Phone;
            student.Email = request.Email;
            student.Password = request.Password;

            await _context.SaveChangesAsync();

            return student;

        }
    }
}
