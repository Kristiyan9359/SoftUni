namespace TravelAgency.Data.Models;

using System.ComponentModel.DataAnnotations;
using static TravelAgency.Common.EntityRelations;
using TravelAgency.Data.Models.Enums;
using System.Diagnostics.SymbolStore;

public class Guide
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(GuideFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [Required]
    public Language Language { get; set; }

    ICollection<TourPackageGuide> TourPackagesGuides { get; set; } = new HashSet<TourPackageGuide>();
}
