using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CarDealer.DTOs.Import;

public class ImportSalesDto
{
    [Required]
    [JsonProperty("carId")]
    public int CarId { get; set; }

    [Required]
    [JsonProperty("customerId")]
    public int CustomerId { get; set; }

    [Required]
    [JsonProperty("discount")]
    public int Discount { get; set; }
}
