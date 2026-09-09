namespace Invoices.DataProcessor.ImportDto;

using Invoices.Data.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static Invoices.Data.Common.EntityRelations.Product;
using static Invoices.Data.Models.Enums.Enums;

public class ImportProductsDto
{
    [JsonProperty("Name")]
    [MinLength(ProductMinLength)]
    [MaxLength(ProductMaxLength)]
    public string Name { get; set; } = null!;


    [JsonProperty("Price")]
    [Range(ProductPriceMinRange,ProductPriceMaxRange)]
    public decimal Price { get; set; }


    [JsonProperty("CategoryType")]
    [Range(0,4)]
    public CategoryType CategoryType { get; set; }

    public int[] Clients { get; set; } = null!;
}
