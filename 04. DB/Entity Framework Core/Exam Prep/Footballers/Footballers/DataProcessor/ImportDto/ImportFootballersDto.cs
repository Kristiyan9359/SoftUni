namespace Footballers.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Common.Validations;

[XmlType("Footballer")]
public class ImportFootballersDto
{
    [Required]
    [XmlElement("Name")]
    [MinLength(FootballerNameMinLength)]
    [MaxLength(FootballerNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement("ContractStartDate")]
    public string ContractStartDate { get; set; } = null!;

    [Required]
    [XmlElement("ContractEndDate")]
    public string ContractEndDate { get; set; } = null!;

    [Required]
    [XmlElement("BestSkillType")]
    [Range(0, 4)]
    public int BestSkillType { get; set; }

    [Required]
    [XmlElement("PositionType")]
    [Range(0, 3)]
    public int PositionType { get; set; }
}
