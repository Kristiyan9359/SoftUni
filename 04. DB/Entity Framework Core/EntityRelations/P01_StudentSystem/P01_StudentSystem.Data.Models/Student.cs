using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    [Index(nameof(PhoneNumber), IsUnique = false)]
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        [Unicode(true)]
        public string Name { get; set; } = null!;

        [MaxLength(10)]
        [Unicode(false)]
        public string? PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> StudentsCourses { get; set; } = new HashSet<StudentCourse>();
        public ICollection<Homework> Homeworks { get; set; } = new HashSet<Homework>();
    }
}
