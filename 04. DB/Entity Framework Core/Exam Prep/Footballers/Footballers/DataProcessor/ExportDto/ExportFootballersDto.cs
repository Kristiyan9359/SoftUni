namespace Footballers.DataProcessor.ExportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Common.Validations;

[XmlType("Footballer")]
public class ExportFootballersDto
{
    [Required]
    [XmlElement("Name")]
    [MinLength(FootballerNameMinLength)]
    [MaxLength(FootballerNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement("Position")]
    public string Position { get; set; } = null!;
}
