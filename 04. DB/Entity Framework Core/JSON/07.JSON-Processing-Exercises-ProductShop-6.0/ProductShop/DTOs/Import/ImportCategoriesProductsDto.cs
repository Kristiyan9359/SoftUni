using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.DTOs.Import;

public class ImportCategoriesProductsDto
{
    [Required]
    [JsonProperty("CategoryId")]
    public int CategoryId { get; set; }


    [Required]
    [JsonProperty("ProductId")]
    public int ProductId { get; set; }
}
