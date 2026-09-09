namespace Footballers.DataProcessor.ExportDto;

using Footballers.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Common.Validations;

[XmlType("Coach")]
public class ExportCoachesWithTheirFootballersDto
{
    [Required]
    [MinLength(CoachNameMinLength)]
    [MaxLength(CoachNameMaxLength)]
    public string CoachName { get; set; } = null!;

    [Required]
    [XmlAttribute("FootballersCount")]
    public int FootballersCount { get; set; }


    [Required]
    [XmlArray("Footballers")]
    public ExportFootballersDto[] Footballers { get; set; } = null!;

}
