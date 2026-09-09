using CarDealer.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.DTOs.Import;

public class ImportCarsDto
{
    [Required]
    [JsonProperty("make")]
    public string Make { get; set; } = null!;

    [Required]
    [JsonProperty("model")]
    public string Model { get; set; } = null!;

    [Required]
    [JsonProperty("traveledDistance")]
    public long TraveledDistance { get; set; }

    [Required]
    [JsonProperty("partsId")]
    public int[] PartsId { get; set; } = null!;
}