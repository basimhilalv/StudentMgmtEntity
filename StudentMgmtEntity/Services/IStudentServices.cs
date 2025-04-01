using StudentMgmtEntity.Models;

namespace StudentMgmtEntity.Services
{
    public interface IStudentServices
    {
        public Task<IEnumerable<Student>> GetStudents();
        public Task<Student> GetOneStudent(int id);
        public Task<Student> AddStudent(StudentDto request);
        public Task<Student> UpdateStudent(int id, StudentDto request);
        public Task<Student> DeleteStudent(int id);
        public Task<IEnumerable<StudentResponse>> GetSearch(string searchword);
    }
}
