using Microsoft.EntityFrameworkCore;
using StudentMgmtEntity.Models;

namespace StudentMgmtEntity.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
