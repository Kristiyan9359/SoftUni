namespace Cadastre.Data.Models;

using System.ComponentModel.DataAnnotations;
using static Cadastre.Common.EntityRelations.Citizen;
using static Cadastre.Data.Enumerations.Enums;

public class Citizen
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CitizenFirstNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(CitizenLastNameMaxLength)]
    public string LastName { get; set; } = null!;

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public MaritalStatus MaritalStatus { get; set; }


    public ICollection<PropertyCitizen> PropertiesCitizens { get; set; }
    = new HashSet<PropertyCitizen>();
}
