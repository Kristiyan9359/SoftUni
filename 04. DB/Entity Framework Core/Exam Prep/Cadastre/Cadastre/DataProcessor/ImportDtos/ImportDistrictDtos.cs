namespace Cadastre.DataProcessor.ImportDtos;

using Cadastre.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Cadastre.Common.EntityRelations.District;

[XmlType("District")]
public class ImportDistrictDtos
{
    [Required]
    [XmlElement("Name")]
    [MinLength(DistrictMinLength)]
    [MaxLength(DistrictMaxLength)]
    public string Name { get; set; } = null!;


    [Required]
    [XmlElement("PostalCode")]
    [RegularExpression(DistrictPostalCodeRegex)]
    public string PostalCode { get; set; } = null!;


    [Required]
    [XmlAttribute("Region")]
    public string Region { get; set; } = null!;


    [Required]
    [XmlArray("Properties")]
    public ImportPropertyDtos[] Properties { get; set; } = null!;
}
