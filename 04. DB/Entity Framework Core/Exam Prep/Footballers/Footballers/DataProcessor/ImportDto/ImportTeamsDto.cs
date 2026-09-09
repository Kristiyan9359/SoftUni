namespace Footballers.DataProcessor.ImportDto;

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static Common.Validations;

public class ImportTeamsDto
{
    [Required]
    [JsonProperty("Name")]
    [RegularExpression(TeamNameRegularExpression)]
    [MinLength(TeamNameMinLength)]
    [MaxLength(TeamNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [JsonProperty("Nationality")]
    [MinLength(TeamNationalityMinLength)]
    [MaxLength(TeamNationalityMaxLength)]
    public string Nationality { get; set; } = null!;

    [Required]
    public int Trophies {  get; set; }

    [Required]
    public int[] Footballers { get; set; } = null!;
}
