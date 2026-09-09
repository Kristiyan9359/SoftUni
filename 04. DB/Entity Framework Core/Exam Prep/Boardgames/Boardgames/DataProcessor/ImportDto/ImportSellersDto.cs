namespace Boardgames.DataProcessor.ImportDto;

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static Common.ValidationConstants;
public class ImportSellersDto
{
    [Required]
    [MinLength(SellerNameMinLength)]
    [MaxLength(SellerNameMaxLength)]
    public string Name { get; set; } = null!;


    [Required]
    [MinLength(SellerAddressMinLength)]
    [MaxLength(SellerAddressMaxLength)]
    public string Address { get; set; } = null!;


    [Required]
    public string Country { get; set; } = null!;


    [Required]
    [RegularExpression(SellerWebsiteRegex)]
    public string Website { get; set; } = null!;

  
    public int[] Boardgames { get; set; } = null!;
}
