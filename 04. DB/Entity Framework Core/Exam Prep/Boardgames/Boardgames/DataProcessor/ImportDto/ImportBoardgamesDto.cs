namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Common.ValidationConstants;

[XmlType("Boardgame")]
public class ImportBoardgamesDto
{
    [Required]
    [XmlElement("Name")]
    [MinLength(GameNameMinLength)]
    [MaxLength(GameNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]

    [XmlElement("Rating")]
    [Range(GameRatingMinRange, GameRatingMaxRange)]
    public double Rating { get; set; }

    [Required]
    [XmlElement("YearPublished")]
    [Range(YearPublishedMinRange, YearPublishedMaxRange)]
    public int YearPublished { get; set; }

    [Required]
    [XmlElement("CategoryType")]
    [Range(0, 4)]
    public int CategoryType { get; set; }

    [Required]
    [XmlElement("Mechanics")]
    public string Mechanics { get; set; } = null!;
}
