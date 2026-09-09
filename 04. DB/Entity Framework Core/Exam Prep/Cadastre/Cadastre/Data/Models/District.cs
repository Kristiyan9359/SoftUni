namespace Cadastre.Data.Models;

using Cadastre.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
using static Cadastre.Common.EntityRelations.District;
using static Cadastre.Data.Enumerations.Enums;

public class District
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(DistrictMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    public string PostalCode { get; set; } = null!;

    [Required]
    public Region Region { get; set; }

    public ICollection<Property> Properties { get; set; }
     = new HashSet<Property>();
}
