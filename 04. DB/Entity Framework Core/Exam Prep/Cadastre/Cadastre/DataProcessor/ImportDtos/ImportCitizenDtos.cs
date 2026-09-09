namespace Cadastre.DataProcessor.ImportDtos;

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static Cadastre.Common.EntityRelations.Citizen;
using static Cadastre.Data.Enumerations.Enums;
public class ImportCitizenDtos
{
    [Required]
    [JsonProperty("FirstName")]
    [MinLength(CitizenFirstNameMinLength)]
    [MaxLength(CitizenLastNameMaxLength)]
    public string FirstName { get; set; } = null!;


    [Required]
    [JsonProperty("LastName")]
    [MinLength(CitizenLastNameMinLength)]
    [MaxLength(CitizenFirstNameMaxLength)]
    public string LastName { get; set; } = null!;


    [Required]
    [JsonProperty("BirthDate")]
    public string BirthDate { get; set; } = null!;


    [Required]
    [JsonProperty("MaritalStatus")]
    [EnumDataType(typeof(MaritalStatus))]
    public string MaritalStatus { get; set; } = null!;


    [Required]
    [JsonProperty("Properties")]
    public int[] Properties { get; set; } = null!;
}
