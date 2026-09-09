using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static P01_StudentSystem.Data.Models.Enums;

namespace P01_StudentSystem.Data.Models;

public class Resource
{
    [Key]
    public int ResourceId { get; set; }

    [Required]
    [MaxLength(50)]
    [Unicode(true)]
    public string Name { get; set; } = null!;

    [Required]
    [Unicode(false)]
    public string Url { get; set; } = null!;

    [Required]
    public ResourceType ResourceType { get; set; }

    [Required]
    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;
}
