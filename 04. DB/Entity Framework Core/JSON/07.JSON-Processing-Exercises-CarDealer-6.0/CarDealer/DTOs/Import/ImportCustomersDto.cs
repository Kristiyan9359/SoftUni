using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.DTOs.Import;

public class ImportCustomersDto
{
    [Required]
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [Required]
    [JsonProperty("birthDate")]
    public string BirthDay { get; set; } = null!;

    [Required]
    [JsonProperty("isYoungDriver")]
    public string IsYoungDriver { get; set; } = null!;
}
