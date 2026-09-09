namespace Invoices.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Invoices.Data.Common.EntityRelations.Address;

[XmlType("Address")]
public class ImportAddressesDto
{
    [XmlElement("StreetName")]
    [MinLength(StreetNameMinLength)]
    [MaxLength(StreetNameMaxLength)]
    public string StreetName { get; set; } = null!;


    [XmlElement("StreetNumber")]
    public int StreetNumber { get; set; }


    [XmlElement("PostCode")]
    public string PostCode { get; set; } = null!;


    [XmlElement("City")]
    [MinLength(CityNameMinLength)]
    [MaxLength(CityNameMaxLength)]
    public string City { get; set; } = null!;


    [XmlElement("Country")]
    [MinLength(CountryNameMinLength)]
    [MaxLength(CountryNameMaxLength)]
    public string Country { get; set; } = null!;
}
