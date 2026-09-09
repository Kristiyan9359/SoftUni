using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static P01_StudentSystem.Data.Models.Enums;

namespace P01_StudentSystem.Data.Models;

public class Homework
{
    [Key]
    public int HomeworkId { get; set; }

    [Required]
    [Unicode(false)]
    public string Content { get; set; } = null!;

    [Required]
    public ContentType ContentType { get; set; }

    [Required]
    public DateTime SubmissionTime { get; set; }

    [Required]
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;

    [Required]
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
}
