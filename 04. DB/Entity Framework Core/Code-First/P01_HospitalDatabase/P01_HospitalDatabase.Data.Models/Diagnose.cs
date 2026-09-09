using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models;

public class Diagnose
{
    [Key]
    public int DiagnoseId { get; set; }


    [Required]
    [StringLength(50)]
    [Unicode(true)]
    public string Name { get; set; } = null!;



    [Required]
    [StringLength(250)]
    [Unicode(true)]
    public string Comments { get; set; } = null!;

    [Required]
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
}
