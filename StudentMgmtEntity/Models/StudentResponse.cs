using System.ComponentModel.DataAnnotations;

namespace StudentMgmtEntity.Models
{
    public class StudentResponse
    {
        [Required]
        public required string Name { get; set; }
        public int Age { get; set; }
        public DateOnly DOB { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public string? Phone { get; set; }
    }
}
