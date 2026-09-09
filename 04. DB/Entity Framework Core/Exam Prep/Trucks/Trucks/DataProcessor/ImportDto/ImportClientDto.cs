namespace Trucks.DataProcessor.ImportDto;

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static Common.Validations;

public class ImportClientDto
{
    [Required]
    [JsonProperty("Name")]
    [MinLength(ClientNameMinLength)]
    [MaxLength(ClientNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [JsonProperty("Nationality")]
    [MinLength(NationalityNameMinLength)]
    [MaxLength(NationalityNameMaxLength)]
    public string Nationality { get; set; } = null!;

    [Required]
    [JsonProperty("Type")]
    public string Type { get; set; } = null!;

    [Required]
    public int[] Trucks { get; set; } = null!;
}
