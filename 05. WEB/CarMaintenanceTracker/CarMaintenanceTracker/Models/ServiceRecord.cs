namespace CarMaintenanceTracker.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ServiceRecord
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey(nameof(Car))]
    public int CarId { get; set; }
    public Car Car { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(ServiceType))]
    public int ServiceTypeId { get; set; }
    public ServiceType ServiceType { get; set; } = null!;

    [Required]
    public DateTime Date { get; set; }

    [Range(0, 1_000_000)]
    public int MileageAtService { get; set; }

    [Range(0, 100_000)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }
}

