namespace Cadastre.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Cadastre.Common.EntityRelations.Property;

public class Property
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(PropertyIdentifierMaxLength)]
    public string PropertyIdentifier { get; set; } = null!;

    [Required]
    public int Area { get; set; }

    [MaxLength(DetailsMaxLength)]
    public string? Details { get; set; }

    [Required]
    [MaxLength(PropertyAddressMaxLength)]
    public string Address { get; set; } = null!;

    [Required]
    public DateTime DateOfAcquisition { get; set; }


    [Required]
    [ForeignKey(nameof(District))]
    public int DistrictId { get; set; }
    public District District { get; set; } = null!;


    public ICollection<PropertyCitizen> PropertiesCitizens { get; set; }
     = new HashSet<PropertyCitizen>();
}
