namespace Cadastre.DataProcessor.ImportDtos;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Cadastre.Common.EntityRelations.Property;

    [XmlType("Property")]
public class ImportPropertyDtos
{
    [Required]
    [XmlElement("PropertyIdentifier")]
    [MinLength(PropertyIdentifierMinLength)]
    [MaxLength(PropertyIdentifierMaxLength)]
    public string PropertyIdentifier { get; set; } = null!;

    [Required]
    [Range(0, int.MaxValue)]
    [XmlElement("Area")]
    public int Area { get; set; }


    [XmlElement("Details")]
    [MinLength(DetailsMinLength)]
    [MaxLength(DetailsMaxLength)]
    public string? Details { get; set; }

    [Required]
    [XmlElement("Address")]
    [MinLength(PropertyAddressMinLength)]
    [MaxLength (PropertyAddressMaxLength)]
    public string Address { get; set; } = null!;


    [Required]
    [XmlElement("DateOfAcquisition")]
    public string DateOfAcquisition { get; set; } = null!;
}
