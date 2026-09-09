using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models;

public class Visitation
{
    [Key]
    public int VisitationId { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [StringLength(250)]
    [Unicode(true)]
    public string Comments { get; set; } = null!;


    [Required]
    public int PatientId { get; set; }

    public Patient Patient { get; set; } = null!;

    [Required]
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;
}
