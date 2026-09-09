namespace CarMaintenanceTracker.Models;

using System.ComponentModel.DataAnnotations;

public class Car
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Brand { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Model { get; set; } = null!;

    [Range(1950, 2026)]
    public int Year { get; set; }

    [Required]
    [StringLength(15)]
    public string LicensePlate { get; set; } = null!;

    [Range(0, 1_000_000)]
    public int CurrentMileage { get; set; }

    public virtual ICollection<ServiceRecord> ServiceRecords { get; set; }
        = new HashSet<ServiceRecord>();
}

