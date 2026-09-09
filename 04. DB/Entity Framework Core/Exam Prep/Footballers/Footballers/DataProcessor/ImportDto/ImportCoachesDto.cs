namespace Footballers.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Common.Validations;

[XmlType("Coach")]
public class ImportCoachesDto
{
    [Required]
    [XmlElement("Name")]
    [MinLength(CoachNameMinLength)]
    [MaxLength(CoachNameMaxLength)]
    public string Name { get; set; } = null!;


    [Required]
    [XmlElement("Nationality")]
    public string Nationality { get; set; } = null!;

    [Required]
    [XmlArray("Footballers")]
    public ImportFootballersDto[] Footballers { get; set; } = null!;
}
