namespace CarMaintenanceTracker.Models;

using System.ComponentModel.DataAnnotations;

public class ServiceType
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;
}

