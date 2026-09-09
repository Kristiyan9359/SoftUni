using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.DTOs.Import;

public class ImportProductsDto
{
    [Required]
    [JsonProperty("Name")]
    public string Name { get; set; } = null!;

    [Required]
    [JsonProperty("Price")]
    public string Price { get; set; } = null!;


    [Required]
    [JsonProperty("SellerId")]
    public string SellerId { get; set; } = null!;


    [JsonProperty("BuyerId")]
    public string? BuyerId { get; set; }
}
