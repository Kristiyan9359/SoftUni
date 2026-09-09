namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Common.ValidationConstants;

[XmlType("Creator")]
public class ImportCreatorsDto
{
    [XmlElement("FirstName")]
    [MinLength(CreatorFirstNameMinLength)]
    [MaxLength(CreatorLastNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [XmlElement("LastName")]
    [MinLength(CreatorLastNameMinLength)]
    [MaxLength(CreatorLastNameMaxLength)]
    public string LastName { get; set; } = null!;

    [XmlArray("Boardgames")]
    public ImportBoardgamesDto[] Boardgames { get; set; } = null!;
}
