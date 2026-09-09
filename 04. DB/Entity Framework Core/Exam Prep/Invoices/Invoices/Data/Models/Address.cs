namespace Invoices.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Common.EntityRelations.Address;

public class Address
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(StreetNameMaxLength)]
    public string StreetName { get; set; } = null!;

    [Required]
    public int StreetNumber { get; set; }

    [Required]
    public string PostCode { get; set; } = null!;

    [Required]
    [MaxLength(CityNameMaxLength)]
    public string City { get; set; } = null!;

    [Required]
    [MaxLength(CountryNameMaxLength)]
    public string Country { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(ClientId))]
    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;
}
