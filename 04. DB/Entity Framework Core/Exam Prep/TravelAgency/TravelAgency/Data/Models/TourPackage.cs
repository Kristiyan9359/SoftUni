namespace TravelAgency.Data.Models;

using System.ComponentModel.DataAnnotations;
using static TravelAgency.Common.EntityRelations;

public class TourPackage
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(TourPackageNameMaxLength)]
    public string PackageName { get; set; } = null!;


    [MaxLength(TourPackageDescriptionMaxLength)]
    public string? Description { get; set; }

    public decimal Price { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

    public ICollection<TourPackageGuide> TourPackagesGuides { get; set; } = new HashSet<TourPackageGuide>();
}
